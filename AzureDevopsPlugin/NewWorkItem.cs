﻿using Microsoft.Office.Interop.Outlook;
using Microsoft.TeamFoundation.ProcessConfiguration.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    public partial class NewWorkItem : Form
    {
        private readonly MailItem _outlookItem;

        public NewWorkItem(MailItem outlookItem)
        {
            if (outlookItem == null)
            {
                throw new ArgumentNullException("outlookItem argument is mandatory");
            }

            _outlookItem = outlookItem;
            InitializeComponent();
            titleTextBox.Text = _outlookItem.Subject;
            descriptionTextBox.BodyHtml = Utility.GetLastMessageFromMessageHTMLBody(outlookItem);
            foreach (var cat in Settings.settings.Categories)
            {
                categoriesComboBox.Items.Add(cat);
            }

            categoriesComboBox.SelectedIndex = 0;
        }

        private bool ValidateWorkItemFields()
        {
            var errorMessage = "";
            if (categoriesComboBox.SelectedItem == null)
            {
                errorMessage += "field categories not selected\n";
            }

            if (string.IsNullOrEmpty(titleTextBox.Text))
            {
                errorMessage += "field title is empty\n";
            }

            if (string.IsNullOrEmpty(descriptionTextBox.BodyHtml))
            {
                errorMessage += "field description is empty\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        private void ChangeEnabledStateOfControls(bool state)
        {
            categoriesComboBox.Enabled = state;
            titleTextBox.Enabled = state;
            descriptionTextBox.Enabled = state;
            attachmentsRadio.Enabled = state;
        }

        private void workItemCreateBtn_Click(object sender, EventArgs e)
        {
            if (Settings.settings.Validate() && ValidateWorkItemFields())
            {
                try
                {
                    ChangeEnabledStateOfControls(false);
                    var category = categoriesComboBox.Text;
                    var title = titleTextBox.Text;
                    var description = descriptionTextBox.BodyHtml;
                    var withAttachments = attachmentsRadio.Checked;
                    var createdWorkItem = Utility.CreateWorkItem(title, description, category, _outlookItem.Attachments, withAttachments);
                    MessageBox.Show("item was created, id = " + createdWorkItem.Id);
                    this.Close();
                }
                finally
                {
                    ChangeEnabledStateOfControls(true);
                }
                
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            titleTextBox.Text = _outlookItem.Subject;
            //descriptionTextBox.Text = Regex.Replace(selObject.Body , @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            descriptionTextBox.Text = Utility.GetLastMessageFromMessageHTMLBody(_outlookItem);
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void setOriginalBodyBtn_Click(object sender, EventArgs e)
        {
            descriptionTextBox.BodyHtml = _outlookItem.HTMLBody;
        }
    }
}