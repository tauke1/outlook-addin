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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly SynchronizationContext _syncContext;
        public SettingsForm()
        {
            InitializeComponent();
            orgNameTextBox.Text = Settings.settings.OrgName;
            projectNameTextBox.Text = Settings.settings.ProjectName;
            patTokenTextBox.Text = Settings.settings.PatToken;
            customCategoryFieldTextBox.Text = Settings.settings.CategoryCustomFieldName;
            workItemTypeTextBox.Text = Settings.settings.WorkItemType;
            if (SynchronizationContext.Current == null)
            {
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            }

            _syncContext = SynchronizationContext.Current;
        }


        public async Task FillCustomCategoryFieldValuesComboBox(bool showError = true)
        {
            try
            {
                _syncContext.Send(new SendOrPostCallback((state) => ChangeEnabledStateOfControls(false)), null);
                if (await Validate(showError))
                {
                    _syncContext.Send(new SendOrPostCallback((state) => FillCategoriesComboBox()), null);
                }
            }
            finally
            {
                _syncContext.Send(new SendOrPostCallback((state) => ChangeEnabledStateOfControls(true)), null);
            }
        }

        private void FillCategoriesComboBox()
        {
            defaultCategoryComboBox.Items.Clear();
            if (Settings.settings.CategoryCustomFieldValues?.Count > 0)
            {
                var categoryCustomFieldDefaultValueFoundIndex = 0;
                var i = 0;
                foreach (var cat in Settings.settings.CategoryCustomFieldValues)
                {
                    defaultCategoryComboBox.Items.Add(cat);
                    if (cat == Settings.settings.CategoryCustomFieldDefaultValue)
                    {
                        categoryCustomFieldDefaultValueFoundIndex = i;
                    }
                    i++;
                }

                defaultCategoryComboBox.SelectedIndex = categoryCustomFieldDefaultValueFoundIndex;

                defaultCategoryComboBox.Enabled = true;
            }
        }

        private async Task<bool> Validate(bool showMessage = true)
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
                errorMessage += "customCategoryField token field is empty\n";
            }

            if (string.IsNullOrEmpty(workItemTypeTextBox.Text))
            {
                errorMessage += "work Item type field is empty\n";
            }


            if (showMessage && !string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    await Utility.ValidateVssSettings(workItemType, projectName, customCategoryField, orgName, patToken);
                    return true;
                }
                catch (System.Exception ex)
                {
                    if (showMessage)
                    {
                        MessageBox.Show(Utility.ProcessException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return false;
        }

        private void ChangeEnabledStateOfControls(bool state)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = state;
            }
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _syncContext.Send(new SendOrPostCallback((state) => ChangeEnabledStateOfControls(false)), null);
                var orgName = orgNameTextBox.Text != null ? orgNameTextBox.Text.Trim() : null;
                var projectName = projectNameTextBox.Text != null ? projectNameTextBox.Text.Trim() : null;
                var patToken = patTokenTextBox.Text != null ? patTokenTextBox.Text.Trim() : null;
                var customCategoryField = customCategoryFieldTextBox.Text != null ? customCategoryFieldTextBox.Text.Trim() : null;
                var workItemType = workItemTypeTextBox.Text != null ? workItemTypeTextBox.Text.Trim() : null;

                if (await Validate())
                {
                    string customDefaultCategory = null;
                    if (defaultCategoryComboBox.SelectedItem != null)
                    {
                        foreach (var cat in Settings.settings.CategoryCustomFieldValues)
                        {
                            if (cat == (string)defaultCategoryComboBox.SelectedItem)
                            {
                                customDefaultCategory = cat;
                            }
                        }
                    }

                    Settings.settings.CategoryCustomFieldName = customCategoryField;
                    Settings.settings.OrgName = orgName;
                    Settings.settings.ProjectName = projectName;
                    Settings.settings.PatToken = patToken;
                    Settings.settings.WorkItemType = workItemType;
                    Settings.settings.CategoryCustomFieldDefaultValue = customDefaultCategory;
                    Settings.settings.Save();
                    _syncContext.Send(new SendOrPostCallback((state) =>
                    {
                        Settings.settings.SendSettingsChangedNotification();
                        this.Close();

                    }), null);
                }
            }
            finally
            {
                _syncContext.Send(new SendOrPostCallback((state) => ChangeEnabledStateOfControls(true)), null);
            }
        }

        private async void reloadCustomFields_Click(object sender, EventArgs e)
        {
            await FillCustomCategoryFieldValuesComboBox();
        }

        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(200);
            await FillCustomCategoryFieldValuesComboBox(false);
        }
    }
}
