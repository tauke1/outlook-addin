using AzureDevopsPlugin.Utilities;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin.Forms
{
    public partial class NewWorkItem : Form
    {
        private readonly MailItem _outlookItem;
        private readonly SynchronizationContext _syncContext;

        public NewWorkItem(MailItem outlookItem)
        {
            if (outlookItem == null)
            {
                throw new ArgumentNullException("outlookItem argument is mandatory");
            }

            _outlookItem = outlookItem;
            InitializeComponent();
            ResetFields();
            if (Models.WorkItem.CategoriesBySource?.Count > 0)
            {
                var selectedIndex = 0;
                var i = 0;
                foreach (var value in Models.WorkItem.CategoriesBySource)
                {
                    if (value == Settings.settings.CategoryBySourceDefaultValue)
                    {
                        selectedIndex = i;
                    }
                    categoriesComboBox.Items.Add(value);
                    i++;
                }

                categoriesComboBox.SelectedIndex = selectedIndex;

                if (SynchronizationContext.Current == null)
                {
                    SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
                }
                _syncContext = SynchronizationContext.Current;
            }

            Settings.settings.SetSettingsChangedNotification(() =>
            {
                categoriesComboBox.Items.Clear();
                categoriesComboBox.SelectedItem = null;
                if (Models.WorkItem.CategoriesByComplexity?.Count > 0)
                {
                    var selectedIndex = 0;
                    var i = 0;
                    foreach (var item in Models.WorkItem.CategoriesByComplexity)
                    {
                        if (item == Settings.settings.CategoryBySourceDefaultValue)
                        {
                            selectedIndex = i;
                        }
                        categoriesComboBox.Items.Add(item);
                        i++;
                    }
                    categoriesComboBox.SelectedIndex = selectedIndex;
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

        /// <summary>
        /// Disable all controls
        /// </summary>
        /// <param name="state"></param>
        private void ChangeEnabledStateOfControls(bool state)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = state;
            }
        }

        /// <summary>
        /// Create work item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void workItemCreateBtn_Click(object sender, EventArgs e)
        {
            if (Settings.settings.Validate() && ValidateWorkItemFields())
            {
                try
                {
                    _syncContext.Send(new SendOrPostCallback((state) => ChangeEnabledStateOfControls(false)), null);
                    var category = categoriesComboBox.Text;
                    var title = titleTextBox.Text;
                    var description = descriptionTextBox.DocumentText;
                    var withAttachments = includeAttachmentsCheckBox.Checked;
                    var createdWorkItem = await TfsUtility.CreateWorkItem(title, description, category, _outlookItem.Attachments, withAttachments);
                    _syncContext.Send(new SendOrPostCallback((state) =>
                    {
                        var workItemCreatedForm = new WorkItemCreated(createdWorkItem.Id.Value);
                        workItemCreatedForm.StartPosition = FormStartPosition.CenterParent;
                        workItemCreatedForm.ShowDialog();
                        this.Close();
                    }), null);
                }
                catch (System.Exception ex)
                {
                    _syncContext.Send(new SendOrPostCallback((state) => MessageBox.Show(TfsUtility.ProcessException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)), null);
                }
                finally
                {
                    _syncContext.Send(new SendOrPostCallback((state) =>
                    {
                        Globals.ThisAddIn.ChangeTaskPaneVisibility(false);
                        ChangeEnabledStateOfControls(true);
                    }), null);
                }

            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        /// <summary>
        /// Reset all fields
        /// </summary>
        private void ResetFields()
        {
            titleTextBox.Text = HtmlUtility.RemoveSubjectAbbreviationsFromSubject(_outlookItem.Subject);
            descriptionTextBox.Html = HtmlUtility.GetLastMessageFromMessageHTMLBody(_outlookItem.HTMLBody);
        }

        private void setOriginalBodyBtn_Click(object sender, EventArgs e)
        {
            descriptionTextBox.Html = _outlookItem.HTMLBody;
        }

        private void removeStylesButton_Click(object sender, EventArgs e)
        {
            descriptionTextBox.Html = HtmlUtility.ClearFormattingOfHtml(descriptionTextBox.DocumentText);
        }
    }
}
