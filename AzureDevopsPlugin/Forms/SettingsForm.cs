using Microsoft.TeamFoundation.WorkItemTracking.Process.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            orgNameTextBox.Text = Settings.settings.OrgName;
            projectNameTextBox.Text = Settings.settings.ProjectName;
            patTokenTextBox.Text = Settings.settings.PatToken;
            customCategoryFieldTextBox.Text = Settings.settings.CategoryCustomFieldName;
            workItemTypeTextBox.Text = Settings.settings.WorkItemType;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var orgName = orgNameTextBox.Text != null ? orgNameTextBox.Text.Trim() : null;
            var projectName = projectNameTextBox.Text != null ? projectNameTextBox.Text.Trim() : null;
            var patToken = patTokenTextBox.Text != null ? patTokenTextBox.Text.Trim() : null;
            var customCategoryField = customCategoryFieldTextBox.Text != null ? customCategoryFieldTextBox.Text.Trim() : null;
            var workItemType = workItemTypeTextBox.Text != null ? workItemTypeTextBox.Text.Trim() : null;
            var errorMessage = "";
            if (string.IsNullOrEmpty(orgName))
            {
                errorMessage += "organization name field is empty\n";
            }

            if (string.IsNullOrEmpty(projectName))
            {
                errorMessage += "project name field is empty\n";
            }

            if (string.IsNullOrEmpty(patToken))
            {
                errorMessage += "PAT token field is empty\n";
            }

            if (string.IsNullOrEmpty(customCategoryField))
            {
                errorMessage += "PAT token field is empty\n";
            }

            if (string.IsNullOrEmpty(workItemTypeTextBox.Text))
            {
                errorMessage += "work Item type field is empty\n";
            }


            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var witClient = Utility.GetTFSHttpClient<WorkItemTrackingHttpClient>(orgName, patToken);
                    var witProcessClient = Utility.GetTFSHttpClient<WorkItemTrackingProcessHttpClient>(orgName, patToken);
                    if (Utility.ValidateVssSettings(workItemType, projectName, customCategoryField, witClient, witProcessClient))
                    {
                        Settings.settings.CategoryCustomFieldName = customCategoryField;
                        Settings.settings.OrgName = orgName;
                        Settings.settings.ProjectName = projectName;
                        Settings.settings.PatToken = patToken;
                        Settings.settings.WorkItemType = workItemType;
                        Settings.settings.Save();
                        Settings.settings.SendSettingsChangedNotification();
                        this.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(Utility.ProcessException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
