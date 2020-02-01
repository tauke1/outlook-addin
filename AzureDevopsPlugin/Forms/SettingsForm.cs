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
            categoriesTextBox.Text = string.Join(",", Settings.settings.Categories.ToArray());
            workItemTypeTextBox.Text = Settings.settings.WorkItemType;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var errorMessage = "";
            if (string.IsNullOrEmpty(orgNameTextBox.Text))
            {
                errorMessage += "organization name field is empty\n";
            }

            if (string.IsNullOrEmpty(projectNameTextBox.Text))
            {
                errorMessage += "project name field is empty\n";
            }

            if (string.IsNullOrEmpty(patTokenTextBox.Text))
            {
                errorMessage += "PAT token field is empty\n";
            }

            if (string.IsNullOrEmpty(categoriesTextBox.Text))
            {
                errorMessage += "PAT token field is empty\n";
            }

            if (string.IsNullOrEmpty(workItemTypeTextBox.Text))
            {
                errorMessage += "work Item type field is empty\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                var list = categoriesTextBox.Text.Split(',').Select(a => a.Trim()).ToList();
                Settings.settings.Categories = list;
                Settings.settings.OrgName = orgNameTextBox.Text.Trim();
                Settings.settings.ProjectName = projectNameTextBox.Text.Trim();
                Settings.settings.PatToken = patTokenTextBox.Text.Trim();
                Settings.settings.WorkItemType = workItemTypeTextBox.Text.Trim();
                Settings.settings.Save();
                this.Close();
            }

        }
    }
}
