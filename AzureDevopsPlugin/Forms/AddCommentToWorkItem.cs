﻿using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin.Forms
{
    public partial class AddCommentToWorkItem : Form
    {
        private readonly MailItem _mailItem;
        public AddCommentToWorkItem(MailItem mailItem, List<Models.WorkItem> workItems, int selectedRow)
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
            commentTextBox.BodyHtml = Utility.GetLastMessageFromMessageHTMLBody(mailItem);
            foreach (var workItem in workItems)
            {
                workItemsRadioButtonList.Items.Add(workItem);
            }
            workItemsRadioButtonList.SelectedIndex = selectedRow;
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

        private bool ValidateCommentFields()
        {
            var errorMessage = "";
            if (workItemsRadioButtonList.SelectedItem == null)
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
            workItemsRadioButtonList.Enabled = enabled;
            includeAttachmentsCheckBox.Enabled = enabled;
        }

        private void addCommentButton_Click(object sender, EventArgs e)
        {
            if (ValidateCommentFields())
            {
                try
                {
                    ChangeEnabledStateOfControls(false);
                    var workItem = (Models.WorkItem)workItemsRadioButtonList.SelectedItem;
                    var comment = commentTextBox.BodyHtml;
                    var withAttachments = includeAttachmentsCheckBox.Checked;
                    var commentEntity = Utility.AddCommentToWorkItem(workItem.Id, comment, _mailItem.Attachments, withAttachments);
                    this.Close();
                }
                finally 
                {
                    Globals.ThisAddIn.ChangeTaskPaneVisibility(false);
                    ChangeEnabledStateOfControls(true);
                }

            }
        }

        private void useOriginalMessageBodyBtn_Click(object sender, EventArgs e)
        {
            commentTextBox.BodyHtml = _mailItem.HTMLBody;
        }

        private void workItemsRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void workItemsRadioButtonList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Settings.settings.Validate())
            {
                if (workItemsRadioButtonList.SelectedItem != null)
                {
                    var selectedItem = (Models.WorkItem)workItemsRadioButtonList.SelectedItem;
                    var link = $"https://dev.azure.com/{Settings.settings.OrgName}/{Settings.settings.ProjectName}/_workitems/edit/{selectedItem.Id}";
                    try
                    {
                        System.Diagnostics.Process.Start(link);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Unable to open link - " + link);
                    }
                }
                
            }
        }
    }
}