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
            this.label1 = new System.Windows.Forms.Label();
            this.useOriginalMessageBodyBtn = new System.Windows.Forms.Button();
            this.includeAttachmentsCheckBox = new System.Windows.Forms.CheckBox();
            this.workItemTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeStylesButton = new System.Windows.Forms.Button();
            this.commentTextBox = new LiveSwitch.TextControl.Editor();
            this.resetButton = new System.Windows.Forms.Button();
            this.statesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.complexityComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // addCommentButton
            // 
            this.addCommentButton.Location = new System.Drawing.Point(25, 1138);
            this.addCommentButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.addCommentButton.Name = "addCommentButton";
            this.addCommentButton.Size = new System.Drawing.Size(371, 55);
            this.addCommentButton.TabIndex = 21;
            this.addCommentButton.Text = "Add comment";
            this.addCommentButton.UseVisualStyleBackColor = true;
            this.addCommentButton.Click += new System.EventHandler(this.addCommentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 401);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "Description";
            // 
            // useOriginalMessageBodyBtn
            // 
            this.useOriginalMessageBodyBtn.Location = new System.Drawing.Point(1436, 1148);
            this.useOriginalMessageBodyBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.useOriginalMessageBodyBtn.Name = "useOriginalMessageBodyBtn";
            this.useOriginalMessageBodyBtn.Size = new System.Drawing.Size(419, 55);
            this.useOriginalMessageBodyBtn.TabIndex = 24;
            this.useOriginalMessageBodyBtn.Text = "Use original message body";
            this.useOriginalMessageBodyBtn.UseVisualStyleBackColor = true;
            this.useOriginalMessageBodyBtn.Click += new System.EventHandler(this.useOriginalMessageBodyBtn_Click);
            // 
            // includeAttachmentsCheckBox
            // 
            this.includeAttachmentsCheckBox.AutoSize = true;
            this.includeAttachmentsCheckBox.Location = new System.Drawing.Point(412, 1148);
            this.includeAttachmentsCheckBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.includeAttachmentsCheckBox.Name = "includeAttachmentsCheckBox";
            this.includeAttachmentsCheckBox.Size = new System.Drawing.Size(307, 36);
            this.includeAttachmentsCheckBox.TabIndex = 28;
            this.includeAttachmentsCheckBox.Text = "include attachments";
            this.includeAttachmentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // workItemTextBox
            // 
            this.workItemTextBox.Location = new System.Drawing.Point(24, 79);
            this.workItemTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.workItemTextBox.Name = "workItemTextBox";
            this.workItemTextBox.Size = new System.Drawing.Size(1871, 38);
            this.workItemTextBox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Work Item";
            // 
            // removeStylesButton
            // 
            this.removeStylesButton.Location = new System.Drawing.Point(844, 1148);
            this.removeStylesButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.removeStylesButton.Name = "removeStylesButton";
            this.removeStylesButton.Size = new System.Drawing.Size(280, 55);
            this.removeStylesButton.TabIndex = 30;
            this.removeStylesButton.Text = "Clear formatting";
            this.removeStylesButton.UseVisualStyleBackColor = true;
            this.removeStylesButton.Click += new System.EventHandler(this.removeStylesButton_Click);
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
            this.commentTextBox.Location = new System.Drawing.Point(25, 449);
            this.commentTextBox.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(1875, 675);
            this.commentTextBox.TabIndex = 22;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(1140, 1148);
            this.resetButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(280, 55);
            this.resetButton.TabIndex = 31;
            this.resetButton.Text = "Reset fields";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // statesComboBox
            // 
            this.statesComboBox.FormattingEnabled = true;
            this.statesComboBox.Location = new System.Drawing.Point(25, 217);
            this.statesComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.statesComboBox.Name = "statesComboBox";
            this.statesComboBox.Size = new System.Drawing.Size(1871, 39);
            this.statesComboBox.TabIndex = 32;
            this.statesComboBox.SelectedIndexChanged += new System.EventHandler(this.statesComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 31);
            this.label3.TabIndex = 33;
            this.label3.Text = "State";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 31);
            this.label4.TabIndex = 35;
            this.label4.Text = "Complexity";
            // 
            // complexityComboBox
            // 
            this.complexityComboBox.Enabled = false;
            this.complexityComboBox.FormattingEnabled = true;
            this.complexityComboBox.Location = new System.Drawing.Point(25, 339);
            this.complexityComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.complexityComboBox.Name = "complexityComboBox";
            this.complexityComboBox.Size = new System.Drawing.Size(1871, 39);
            this.complexityComboBox.TabIndex = 34;
            // 
            // AddCommentToWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1923, 1257);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.complexityComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statesComboBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.removeStylesButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.workItemTextBox);
            this.Controls.Add(this.includeAttachmentsCheckBox);
            this.Controls.Add(this.useOriginalMessageBodyBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.addCommentButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddCommentToWorkItem";
            this.Text = "Add Comment To Work Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCommentButton;
        private LiveSwitch.TextControl.Editor commentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button useOriginalMessageBodyBtn;
        private System.Windows.Forms.CheckBox includeAttachmentsCheckBox;
        private System.Windows.Forms.TextBox workItemTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeStylesButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ComboBox statesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox complexityComboBox;
    }
}