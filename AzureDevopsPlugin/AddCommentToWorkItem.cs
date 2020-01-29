using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    public partial class AddCommentToWorkItem : Form
    {
        private readonly MailItem _mailItem;
        public AddCommentToWorkItem(MailItem mailItem, List<Models.WorkItem> workItems)
        {
            if (workItems == null || workItems.Count == 0)
            {
                throw new ArgumentNullException("workItems property is empty");
            }
            if (mailItem == null)
            {
                throw new ArgumentNullException("mailItem property is required");
            }
            _mailItem = mailItem;
            InitializeComponent();
            commentTextBox.BodyHtml = _mailItem.HTMLBody;
            foreach (var workItem in workItems)
            {
                workItemsListComboBox.Items.Add(workItem);
            }
        }


        private void workItemsListComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            // Get the item text
            var item = (Models.WorkItem)(((ComboBox)sender).Items[e.Index]);
            // Determine the forecolor based on whether or not the item is selected    
            e.Graphics.DrawRectangle(new Pen(Color.White), e.Bounds);
            e.Graphics.FillRectangle(new SolidBrush(item.StateColor), e.Bounds);
            // Draw the text    
            e.Graphics.DrawString(item.ToString(), ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private bool ValidatCommentFields()
        {
            var errorMessage = "";
            if (workItemsListComboBox.SelectedItem == null)
            {
                errorMessage += "field work item not selected\n";
            }

            if (string.IsNullOrEmpty(commentTextBox.BodyHtml))
            {
                errorMessage += "field comment is empty\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        private void ChangeEnabledStateOfControls(bool enabled)
        {
            commentTextBox.Enabled = enabled;
            workItemsListComboBox.Enabled = enabled;
            addAttachmentsToCommentRadio.Enabled = enabled;
        }

        private void addCommentButton_Click(object sender, EventArgs e)
        {
            if (ValidatCommentFields())
            {
                try
                {
                    ChangeEnabledStateOfControls(false);
                    var workItem = (Models.WorkItem)workItemsListComboBox.SelectedItem;
                    var comment = commentTextBox.BodyHtml;
                    var withAttachments = addAttachmentsToCommentRadio.Checked;
                    Utility.AddCommentToWorkItem(workItem.Id, comment, _mailItem.Attachments, withAttachments);
                }
                finally 
                {
                    ChangeEnabledStateOfControls(true);
                }

            }
        }
    }
}
