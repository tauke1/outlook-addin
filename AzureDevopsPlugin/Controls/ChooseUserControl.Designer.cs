namespace AzureDevopsPlugin.Controls
{
    partial class ChooseUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userLabel = new System.Windows.Forms.Label();
            this.newWorkItemBtn = new System.Windows.Forms.Button();
            this.addCommentBtn = new System.Windows.Forms.Button();
            this.workItemGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workItemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(12, 24);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(251, 13);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "One or more work item found by current mail subject";
            // 
            // newWorkItemBtn
            // 
            this.newWorkItemBtn.Location = new System.Drawing.Point(29, 389);
            this.newWorkItemBtn.Name = "newWorkItemBtn";
            this.newWorkItemBtn.Size = new System.Drawing.Size(108, 23);
            this.newWorkItemBtn.TabIndex = 1;
            this.newWorkItemBtn.Text = "New Work Item";
            this.newWorkItemBtn.UseVisualStyleBackColor = true;
            this.newWorkItemBtn.Click += new System.EventHandler(this.newWorkItemBtn_Click);
            // 
            // addCommentBtn
            // 
            this.addCommentBtn.Location = new System.Drawing.Point(155, 389);
            this.addCommentBtn.Name = "addCommentBtn";
            this.addCommentBtn.Size = new System.Drawing.Size(108, 23);
            this.addCommentBtn.TabIndex = 2;
            this.addCommentBtn.Text = "Add Comment";
            this.addCommentBtn.UseVisualStyleBackColor = true;
            this.addCommentBtn.Click += new System.EventHandler(this.addCommentBtn_Click);
            // 
            // workItemGridView
            // 
            this.workItemGridView.AllowUserToAddRows = false;
            this.workItemGridView.AllowUserToDeleteRows = false;
            this.workItemGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.workItemGridView.BackgroundColor = System.Drawing.Color.White;
            this.workItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workItemGridView.ColumnHeadersVisible = false;
            this.workItemGridView.Location = new System.Drawing.Point(15, 59);
            this.workItemGridView.MultiSelect = false;
            this.workItemGridView.Name = "workItemGridView";
            this.workItemGridView.ReadOnly = true;
            this.workItemGridView.RowHeadersVisible = false;
            this.workItemGridView.RowHeadersWidth = 102;
            this.workItemGridView.ShowCellErrors = false;
            this.workItemGridView.ShowEditingIcon = false;
            this.workItemGridView.ShowRowErrors = false;
            this.workItemGridView.Size = new System.Drawing.Size(248, 302);
            this.workItemGridView.TabIndex = 3;
            this.workItemGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workItemGridView_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(39, 367);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Double click on a row to open Work Item_";
            // 
            // ChooseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workItemGridView);
            this.Controls.Add(this.addCommentBtn);
            this.Controls.Add(this.newWorkItemBtn);
            this.Controls.Add(this.userLabel);
            this.Name = "ChooseUserControl";
            this.Size = new System.Drawing.Size(281, 422);
            this.Resize += new System.EventHandler(this.ChooseUserControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.workItemGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button newWorkItemBtn;
        private System.Windows.Forms.Button addCommentBtn;
        private System.Windows.Forms.DataGridView workItemGridView;
        private System.Windows.Forms.Label label1;
    }
}
