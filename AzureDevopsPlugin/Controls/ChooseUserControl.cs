using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using AzureDevopsPlugin.Forms;

namespace AzureDevopsPlugin.Controls
{
    public partial class ChooseUserControl : UserControl
    {
        private MailItem _mailItem;
        private List<Models.WorkItem> _workItems;

        public ChooseUserControl()
        {
            InitializeComponent();
            workItemGridView.ColumnHeadersVisible = false;
            workItemGridView.Columns.Add("Color", "Color");
            workItemGridView.Columns.Add("Id", "Id");
            workItemGridView.Columns.Add("Title", "Title");
            workItemGridView.Columns[0].Width = 15;
            workItemGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public void FillTaskPane(List<Models.WorkItem> workItems, MailItem mailItem)
        {
            if (workItems?.Count == 0)
            {
                //throw new ArgumentNullException("workItems property is empty");
                addCommentBtn.Enabled = false;
            }
            else
            {
                addCommentBtn.Enabled = true;
            }

            if (mailItem == null)
            {
                throw new ArgumentNullException("mailItem property is empty");
            }

            userLabel.Text = $"{workItems?.Count} work item found by current mail subject";
            _mailItem = mailItem;
            _workItems = workItems;
            workItemGridView.Rows.Clear();
            var i = 0;
            foreach (var workItem in workItems)
            {
                workItemGridView.Rows.Add("",workItem.Id, workItem.Title);
                workItemGridView.Rows[i].Cells[0].Style.BackColor = workItem.StateColor;
                i++;
            }
        }

        private void newWorkItemBtn_Click(object sender, EventArgs e)
        {
            var form = new NewWorkItem(_mailItem);
            Utility.MoveFormToCenterAndShow(form);
        }

        private void addCommentBtn_Click(object sender, EventArgs e)
        {
            var form = new AddCommentToWorkItem(_mailItem, _workItems[workItemGridView.CurrentCell.RowIndex]);
            Utility.MoveFormToCenterAndShow(form);
        }

        private void workItemGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Settings.settings.Validate())
            {
                var selectedItem = workItemGridView.Rows[workItemGridView.CurrentCell.RowIndex].Cells["Id"].Value;
                var link = $"https://dev.azure.com/{Settings.settings.OrgName}/{Settings.settings.ProjectName}/_workitems/edit/{selectedItem}";
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
