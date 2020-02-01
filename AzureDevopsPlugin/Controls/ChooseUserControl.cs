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
            workItemGridView.Columns.Add("Id", "Id");
            workItemGridView.Columns.Add("Title", "Title");
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
            foreach (var workItem in workItems)
            {
                workItemGridView.Rows.Add(workItem.Id, workItem.Title);
            }
        }

        private void newWorkItemBtn_Click(object sender, EventArgs e)
        {
            var form = new NewWorkItem(_mailItem);
            Utility.MoveFormToCenterAndShow(form);
        }

        private void addCommentBtn_Click(object sender, EventArgs e)
        {
            var form = new AddCommentToWorkItem(_mailItem, _workItems, workItemGridView.CurrentCell.RowIndex);
            Utility.MoveFormToCenterAndShow(form);
        }
    }
}
