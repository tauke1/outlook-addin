using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin.Forms
{
    public partial class AddCommentToWorkItem : Form
    {
        private readonly MailItem _mailItem;
        private readonly Models.WorkItem _workItem;
        private readonly SynchronizationContext _syncContext;
        public AddCommentToWorkItem(MailItem mailItem, Models.WorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException("workItems property is empty");
            }
            if (mailItem == null)
            {
                throw new ArgumentNullException("mailItem property is required");
            }

            _workItem = workItem;
            _mailItem = mailItem;
            InitializeComponent();
            commentTextBox.Html = Utility.RemoveHeaderFromHtml(Utility.GetLastMessageFromMessageHTMLBody(mailItem.HTMLBody));
            workItemTextBox.Text = workItem.ToString();
            workItemTextBox.Enabled = false;
            if (SynchronizationContext.Current == null)
            {
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            }
            _syncContext = SynchronizationContext.Current;
        }

        private bool ValidateCommentFields()
        {
            var errorMessage = "";
            if (string.IsNullOrEmpty(commentTextBox.BodyHtml))
            {
                errorMessage += "field comment is empty\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ChangeEnabledStateOfControls(bool state)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = state;
            }
        }

        private async void addCommentButton_Click(object sender, EventArgs e)
        {
            if (ValidateCommentFields())
            {
                try
                {
                    _syncContext.Send( new SendOrPostCallback((state)=> ChangeEnabledStateOfControls(false)), null);
                    var comment = commentTextBox.DocumentText;
                    var withAttachments = includeAttachmentsCheckBox.Checked;
                    var commentEntity = await Utility.AddCommentToWorkItem(_workItem.Id, comment, _mailItem.Attachments, withAttachments);
                    _syncContext.Send(new SendOrPostCallback((state) => this.Close()),null);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(Utility.ProcessException(ex),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                {
                    _syncContext.Send(new SendOrPostCallback((state) => {
                        Globals.ThisAddIn.ChangeTaskPaneVisibility(false);
                        ChangeEnabledStateOfControls(true);
                    }), null);

                }

            }
        }

        private void useOriginalMessageBodyBtn_Click(object sender, EventArgs e)
        {
            commentTextBox.Html = Utility.RemoveHeaderFromHtml(_mailItem.HTMLBody);
        }

        private void removeStylesButton_Click(object sender, EventArgs e)
        {
            commentTextBox.Html = Utility.RemoveHeaderFromHtml(Utility.ClearFormattingOfHtml(commentTextBox.DocumentText));
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            commentTextBox.Html = Utility.RemoveHeaderFromHtml(Utility.GetLastMessageFromMessageHTMLBody(_mailItem.HTMLBody));
        }
    }
}
