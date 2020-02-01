using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Data;
using System.IO;
using System.Xml;
using Microsoft.Office.Interop.Outlook;
using AzureDevopsPlugin.Controls;
using Microsoft.Office.Tools;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    public partial class ThisAddIn
    {
        private Explorer _activeExplorer;
        private CustomTaskPane _customTaskPane;

        public void ChangeTaskPaneVisibility(bool visibility)
        {
            _customTaskPane.Visible = visibility;
        }

        public void FillTaskPane(List<Models.WorkItem> workItems, MailItem mailItem)
        {
            var control = (ChooseUserControl)(_customTaskPane.Control);
            control.FillTaskPane(workItems,  mailItem);
            ChangeTaskPaneVisibility(true);
        }


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _activeExplorer = Application.Explorers[1];
            _activeExplorer.SelectionChange += _activeExplorer_SelectionChange;

            var control = new ChooseUserControl();
            var width = control.Width;
            _customTaskPane = this.CustomTaskPanes.Add(control, "VSTS");
            _customTaskPane.Width = width;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void _activeExplorer_SelectionChange()
        {
            ChangeTaskPaneVisibility(false);
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
    }
}
#endregion