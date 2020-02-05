using Microsoft.Office.Interop.Outlook;
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

namespace AzureDevopsPlugin.Forms
{
    public partial class NewWorkItem : Form
    {
        private readonly MailItem _outlookItem;

        public NewWorkItem()
        {

        }

        public NewWorkItem(MailItem outlookItem)
        {
            if (outlookItem == null)
            {
                throw new ArgumentNullException("outlookItem argument is mandatory");
            }

            _outlookItem = outlookItem;
            InitializeComponent();
            ResetFields();
            if (Settings.settings.CategoryCustomFieldValues?.Count > 0)
            {
                var selectedIndex = 0;
                var i = 0;
                foreach (var value in Settings.settings.CategoryCustomFieldValues)
                {
                    if (value == Settings.settings.CategoryCustomFieldDefaultValue)
                    {
                        selectedIndex = i; 
                    }
                    categoriesComboBox.Items.Add(value);
                    i++;
                }

                categoriesComboBox.SelectedIndex = selectedIndex;
            }


            Settings.settings.SetSettingsChangedNotification(() =>
            {
                categoriesComboBox.Items.Clear();
                if (Settings.settings.CategoryCustomFieldValues?.Count > 0)
                {
                    foreach (var item in Settings.settings.CategoryCustomFieldValues)
                    {
                        categoriesComboBox.Items.Add(item);
                    }
                    categoriesComboBox.SelectedIndex = 0;
                }
            });
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
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ChangeEnabledStateOfControls(bool state)
        {
            categoriesComboBox.Enabled = state;
            descriptionTextBox.Enabled = state;
            includeAttachmentsCheckBox.Enabled = state;
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
                    var withAttachments = includeAttachmentsCheckBox.Checked;
                    var createdWorkItem = Utility.CreateWorkItem(title, description, category, _outlookItem.Attachments, withAttachments);
                    var workItemCreatedForm = new WorkItemCreated(createdWorkItem.Id.Value);
                    workItemCreatedForm.StartPosition = FormStartPosition.CenterParent;
                    workItemCreatedForm.ShowDialog();
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(Utility.ProcessException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Globals.ThisAddIn.ChangeTaskPaneVisibility(false);
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
            titleTextBox.Text = Utility.RemoveSubjectAbbreviationsFromSubject(_outlookItem.Subject);
            //descriptionTextBox.Text = Regex.Replace(selObject.Body , @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            descriptionTextBox.BodyHtml = Utility.GetLastMessageFromMessageHTMLBody(_outlookItem);
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
