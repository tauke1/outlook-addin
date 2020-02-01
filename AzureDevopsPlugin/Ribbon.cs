using AzureDevopsPlugin.Forms;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace AzureDevopsPlugin
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private bool _createWorkItemButtonEnabled = true;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;

        public Ribbon()
        {
            if (SynchronizationContext.Current == null)
            {
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            }
            synchronizationContext = new WindowsFormsSynchronizationContext();
        }

        public void EditSettings(Office.IRibbonControl control)
        {
            Globals.ThisAddIn.ChangeTaskPaneVisibility(false);
            var form = new SettingsForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            Settings.settings.Reload();
        }

        public bool CreateWorkItemButton_GetEnabled(Office.IRibbonControl rControl)
        {
            return _createWorkItemButtonEnabled;
        }

        public void CreateWorkItem(Office.IRibbonControl control)
        {
            if (Settings.settings.Validate())
            {
                // Determine subject of selected item
                Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
                if (explorer != null && explorer.Selection != null && explorer.Selection.Count > 0)
                {
                    var mailItem = explorer.Selection[1] as MailItem;
                    if (mailItem == null)
                    {
                        return;
                    }

                    _createWorkItemButtonEnabled = false;
                    ribbon.InvalidateControl("CreateWorkItem");
                    Task.Run(() =>
                    {
                        try
                        {
                            var workItems = Utility.FindWorkItemsByTitle(Utility.RemoveSubjectAbbreviationsFromSubject(mailItem.Subject)).Result;
                            synchronizationContext.Post(new SendOrPostCallback(o => Globals.ThisAddIn.FillTaskPane(workItems, mailItem)), null);
                            //synchronizationContext.Send(new SendOrPostCallback(o => CreateNewWorkItemsFormOrChooseForm(workItems, mailItem)), null);
                        }
                        finally
                        {
                            synchronizationContext.Send(new SendOrPostCallback(o => EnableCreateNewWorkItemButton()), null);
                        }
                    });
                }
            }
        }

        //private void CreateNewWorkItemsFormOrChooseForm(List<Models.WorkItem> workItems, MailItem mailItem)
        //{
        //    Form form = workItems?.Count > 0 ? (Form)(new ChooseForm(workItems, mailItem)) : new NewWorkItem(mailItem);
        //    Utility.MoveFormToCenterAndShow(form);
        //}

        private async void EnableCreateNewWorkItemButton()
        {
            _createWorkItemButtonEnabled = true;
            ribbon.InvalidateControl("CreateWorkItem");
        }
        #region IRibbonExtensibility Members


        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("AzureDevopsPlugin.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
