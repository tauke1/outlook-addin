using Microsoft.Office.Interop.Outlook;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace AzureDevopsPlugin
{
    partial class WorkItemRegion
    {
        #region Form Region Factory 

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Activity)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("AzureDevopsPlugin.WorkItemRegion")]
        public partial class WorkItemRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void WorkItemRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void WorkItemRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void WorkItemRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
        }

        private void editSettingsButton_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            Settings.settings.Reload();
        }

        private void newWorkItemBtn_Click(object sender, EventArgs e)
        {
            dynamic window = Globals.ThisAddIn.Application.ActiveWindow();
            var newWorkItemForm = new NewWorkItem((MailItem)this.OutlookItem);
            newWorkItemForm.StartPosition = FormStartPosition.Manual;
            MoveFormToCenter(newWorkItemForm);
            newWorkItemForm.Show();
        }

        private void addCommentBtn_Click(object sender, EventArgs e)
        {
            if (Settings.settings.Validate())
            {
                var workItems = Utility.FindWorkItemsByTitle(((MailItem)this.OutlookItem).Subject);
                MessageBox.Show(workItems.Count + " work items found with same title as current message subject");
                if (workItems.Count > 0)
                {
                    dynamic window = Globals.ThisAddIn.Application.ActiveWindow();
                    var form = new AddCommentToWorkItem((MailItem)this.OutlookItem, workItems);
                    form.StartPosition = FormStartPosition.Manual;
                    MoveFormToCenter(form);
                    form.Show();
                }
            }
        }

        // Я сделал центрирования форм которые не блочат интерефейс, т.е которые вызываются через Show(), обычным способом не пашет
        private void MoveFormToCenter(Form child)
        {
            child.StartPosition = FormStartPosition.Manual;
            dynamic window = Globals.ThisAddIn.Application.ActiveWindow();
            child.Location = new Point(window.Left + ((window.Width - child.Width) / 2) , window.Top  + ((window.Height - child.Height) / 2));
        }
    }
}