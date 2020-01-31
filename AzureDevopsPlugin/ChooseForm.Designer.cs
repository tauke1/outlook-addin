namespace AzureDevopsPlugin
{
    partial class ChooseForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createNewWorkItemBtn = new System.Windows.Forms.Button();
            this.addCommentBtn = new System.Windows.Forms.Button();
            this.userLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createNewWorkItemBtn
            // 
            this.createNewWorkItemBtn.Location = new System.Drawing.Point(42, 107);
            this.createNewWorkItemBtn.Name = "createNewWorkItemBtn";
            this.createNewWorkItemBtn.Size = new System.Drawing.Size(136, 23);
            this.createNewWorkItemBtn.TabIndex = 0;
            this.createNewWorkItemBtn.Text = "Create new work item";
            this.createNewWorkItemBtn.UseVisualStyleBackColor = true;
            this.createNewWorkItemBtn.Click += new System.EventHandler(this.createNewWorkItemBtn_Click);
            // 
            // addCommentBtn
            // 
            this.addCommentBtn.Location = new System.Drawing.Point(210, 107);
            this.addCommentBtn.Name = "addCommentBtn";
            this.addCommentBtn.Size = new System.Drawing.Size(201, 23);
            this.addCommentBtn.TabIndex = 1;
            this.addCommentBtn.Text = "Add comment to existing work item";
            this.addCommentBtn.UseVisualStyleBackColor = true;
            this.addCommentBtn.Click += new System.EventHandler(this.addCommentBtn_Click);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(39, 24);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(35, 13);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "label1";
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 144);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.addCommentBtn);
            this.Controls.Add(this.createNewWorkItemBtn);
            this.Name = "ChooseForm";
            this.Text = "ChooseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createNewWorkItemBtn;
        private System.Windows.Forms.Button addCommentBtn;
        private System.Windows.Forms.Label userLabel;
    }
}