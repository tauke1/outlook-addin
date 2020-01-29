namespace AzureDevopsPlugin
{
    partial class AddCommentToWorkItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCommentToWorkItem));
            this.addCommentButton = new System.Windows.Forms.Button();
            this.addAttachmentsToCommentRadio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.workItemsListComboBox = new System.Windows.Forms.ComboBox();
            this.commentTextBox = new LiveSwitch.TextControl.Editor();
            this.label1 = new System.Windows.Forms.Label();
            this.useOriginalMessageBodyBtn = new System.Windows.Forms.Button();
            this.workItemLink = new System.Windows.Forms.LinkLabel();
            this.workItemLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            this.SuspendLayout();
            // 
            // addCommentButton
            // 
            this.addCommentButton.Location = new System.Drawing.Point(14, 390);
            this.addCommentButton.Name = "addCommentButton";
            this.addCommentButton.Size = new System.Drawing.Size(139, 23);
            this.addCommentButton.TabIndex = 21;
            this.addCommentButton.Text = "Add comment";
            this.addCommentButton.UseVisualStyleBackColor = true;
            this.addCommentButton.Click += new System.EventHandler(this.addCommentButton_Click);
            // 
            // addAttachmentsToCommentRadio
            // 
            this.addAttachmentsToCommentRadio.AutoSize = true;
            this.addAttachmentsToCommentRadio.Location = new System.Drawing.Point(162, 393);
            this.addAttachmentsToCommentRadio.Name = "addAttachmentsToCommentRadio";
            this.addAttachmentsToCommentRadio.Size = new System.Drawing.Size(103, 17);
            this.addAttachmentsToCommentRadio.TabIndex = 19;
            this.addAttachmentsToCommentRadio.TabStop = true;
            this.addAttachmentsToCommentRadio.Text = "withAttachments";
            this.addAttachmentsToCommentRadio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Work Item";
            // 
            // workItemsListComboBox
            // 
            this.workItemsListComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.workItemsListComboBox.FormattingEnabled = true;
            this.workItemsListComboBox.Location = new System.Drawing.Point(14, 38);
            this.workItemsListComboBox.Name = "workItemsListComboBox";
            this.workItemsListComboBox.Size = new System.Drawing.Size(214, 21);
            this.workItemsListComboBox.TabIndex = 17;
            this.workItemsListComboBox.SelectedIndexChanged += new System.EventHandler(this.workItemsListComboBox_SelectedIndexChanged);
            this.workItemsListComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(workItemsListComboBox_DrawItem);
            // 
            // commentTextBox
            // 
            this.commentTextBox.BodyBackgroundColor = System.Drawing.Color.White;
            this.commentTextBox.BodyHtml = null;
            this.commentTextBox.BodyText = null;
            this.commentTextBox.DocumentText = resources.GetString("commentTextBox.DocumentText");
            this.commentTextBox.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commentTextBox.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.commentTextBox.FontSize = LiveSwitch.TextControl.FontSize.Three;
            this.commentTextBox.Html = null;
            this.commentTextBox.Location = new System.Drawing.Point(14, 91);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(645, 283);
            this.commentTextBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Description";
            // 
            // useOriginalMessageBodyBtn
            // 
            this.useOriginalMessageBodyBtn.Location = new System.Drawing.Point(573, 390);
            this.useOriginalMessageBodyBtn.Name = "useOriginalMessageBodyBtn";
            this.useOriginalMessageBodyBtn.Size = new System.Drawing.Size(86, 23);
            this.useOriginalMessageBodyBtn.TabIndex = 24;
            this.useOriginalMessageBodyBtn.Text = "Use original message bod";
            this.useOriginalMessageBodyBtn.UseVisualStyleBackColor = true;
            this.useOriginalMessageBodyBtn.Click += new System.EventHandler(this.useOriginalMessageBodyBtn_Click);
            // 
            // workItemLink
            // 
            this.workItemLink.AutoSize = true;
            this.workItemLink.Location = new System.Drawing.Point(243, 41);
            this.workItemLink.Name = "workItemLink";
            this.workItemLink.Size = new System.Drawing.Size(55, 13);
            this.workItemLink.TabIndex = 25;
            this.workItemLink.TabStop = true;
            this.workItemLink.Text = "linkLabel1";
            // 
            // AddCommentToWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 425);
            this.Controls.Add(this.workItemLink);
            this.Controls.Add(this.useOriginalMessageBodyBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.addCommentButton);
            this.Controls.Add(this.addAttachmentsToCommentRadio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.workItemsListComboBox);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "AddCommentToWorkItem";
            this.Text = "AddCommentToWorkItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCommentButton;
        private System.Windows.Forms.RadioButton addAttachmentsToCommentRadio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox workItemsListComboBox;
        private LiveSwitch.TextControl.Editor commentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button useOriginalMessageBodyBtn;
        private System.Windows.Forms.LinkLabel workItemLink;
    }
}