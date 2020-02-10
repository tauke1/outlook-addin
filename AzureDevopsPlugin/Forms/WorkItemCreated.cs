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
    public partial class WorkItemCreated : Form
    {
        private int _workItemId { get; set; }
        public WorkItemCreated(int workItemId)
        {
            _workItemId = workItemId;
            InitializeComponent();
            workItemLabel.Text = "Work item successfully created, work item id is " + _workItemId;
        }

        private void openBrowser_Click(object sender, EventArgs e)
        {
            if (Settings.settings.Validate())
            { 
                var url = $"https://dev.azure.com/{Settings.settings.OrgName}/{Settings.settings.ProjectName}/_workitems/edit/{_workItemId}";
                try
                {
                    System.Diagnostics.Process.Start(url);
                }
                catch (System.Exception ex)
                {
                }
            }
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
