using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    public partial class ChooseForm : Form
    {
        private MailItem _mailItem;
        private List<Models.WorkItem> _workItems;
        public ChooseForm(List<Models.WorkItem> workItems, MailItem mailItem)
        {
            if (workItems?.Count == 0)
            {
                throw new ArgumentNullException("workItems argument is empty");
            }

            if (mailItem == null)
            {
                throw new ArgumentNullException("mailItem argument is empty");
            }

            _mailItem = mailItem;
            _workItems = workItems;
            InitializeComponent();
            userLabel.Text = "There are found " + workItems.Count + " work items with mail subject title";
            userLabel.Text += "\n work items ids - " + string.Join(", ", workItems.Select(a=>a.Id.ToString()).ToArray());
        }

        private void createNewWorkItemBtn_Click(object sender, EventArgs e)
        {
            var form = new NewWorkItem(_mailItem);
            Utility.MoveFormToCenterAndShow(form);
            this.Close();
        }

        private void addCommentBtn_Click(object sender, EventArgs e)
        {
            var form = new AddCommentToWorkItem(_mailItem, _workItems);
            form.Text = Utility.RemoveSubjectAbbreviationsFromSubject(_mailItem.Subject);
            Utility.MoveFormToCenterAndShow(form);
            this.Close();
        }
    }
}
