namespace AzureDevopsPlugin.Forms
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
            this.label5 = new System.Windows.Forms.Label();
            this.commentTextBox = new LiveSwitch.TextControl.Editor();
            this.label1 = new System.Windows.Forms.Label();
            this.useOriginalMessageBodyBtn = new System.Windows.Forms.Button();
            this.includeAttachmentsCheckBox = new System.Windows.Forms.CheckBox();
            this.workItemsRadioButtonList = new RadioButtonList1();
            this.SuspendLayout();
            // 
            // addCommentButton
            // 
            this.addCommentButton.Location = new System.Drawing.Point(13, 333);
            this.addCommentButton.Name = "addCommentButton";
            this.addCommentButton.Size = new System.Drawing.Size(139, 23);
            this.addCommentButton.TabIndex = 21;
            this.addCommentButton.Text = "Add comment";
            this.addCommentButton.UseVisualStyleBackColor = true;
            this.addCommentButton.Click += new System.EventHandler(this.addCommentButton_Click);
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
            this.commentTextBox.Location = new System.Drawing.Point(231, 38);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(645, 283);
            this.commentTextBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Description";
            // 
            // useOriginalMessageBodyBtn
            // 
            this.useOriginalMessageBodyBtn.Location = new System.Drawing.Point(719, 333);
            this.useOriginalMessageBodyBtn.Name = "useOriginalMessageBodyBtn";
            this.useOriginalMessageBodyBtn.Size = new System.Drawing.Size(157, 23);
            this.useOriginalMessageBodyBtn.TabIndex = 24;
            this.useOriginalMessageBodyBtn.Text = "Use original message body";
            this.useOriginalMessageBodyBtn.UseVisualStyleBackColor = true;
            this.useOriginalMessageBodyBtn.Click += new System.EventHandler(this.useOriginalMessageBodyBtn_Click);
            // 
            // includeAttachmentsCheckBox
            // 
            this.includeAttachmentsCheckBox.AutoSize = true;
            this.includeAttachmentsCheckBox.Location = new System.Drawing.Point(158, 337);
            this.includeAttachmentsCheckBox.Name = "includeAttachmentsCheckBox";
            this.includeAttachmentsCheckBox.Size = new System.Drawing.Size(121, 17);
            this.includeAttachmentsCheckBox.TabIndex = 28;
            this.includeAttachmentsCheckBox.Text = "include attachments";
            this.includeAttachmentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // workItemsRadioButtonList
            // 
            this.workItemsRadioButtonList.FormattingEnabled = true;
            this.workItemsRadioButtonList.HorizontalExtent = 300;
            this.workItemsRadioButtonList.HorizontalScrollbar = true;
            this.workItemsRadioButtonList.Location = new System.Drawing.Point(3, 38);
            this.workItemsRadioButtonList.Name = "workItemsRadioButtonList";
            this.workItemsRadioButtonList.Size = new System.Drawing.Size(220, 289);
            this.workItemsRadioButtonList.TabIndex = 30;
            this.workItemsRadioButtonList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.workItemsRadioButtonList_MouseDoubleClick);
            // 
            // AddCommentToWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 359);
            this.Controls.Add(this.workItemsRadioButtonList);
            this.Controls.Add(this.includeAttachmentsCheckBox);
            this.Controls.Add(this.useOriginalMessageBodyBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.addCommentButton);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "AddCommentToWorkItem";
            this.Text = "AddCommentToWorkItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCommentButton;
        private System.Windows.Forms.Label label5;
        private LiveSwitch.TextControl.Editor commentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button useOriginalMessageBodyBtn;
        private System.Windows.Forms.CheckBox includeAttachmentsCheckBox;
        private RadioButtonList1 workItemsRadioButtonList;
    }
}