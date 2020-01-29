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
    public partial class WysywigForm : Form
    {
        private RichTextBox parentTextBox { get; set; }
        public WysywigForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            parentTextBox.Text = editor.BodyHtml;
            this.Close();
        }

        public void SetParent(RichTextBox textBox)
        {
            parentTextBox = textBox;
            editor.BodyHtml = textBox.Text;
        }

    }
}
