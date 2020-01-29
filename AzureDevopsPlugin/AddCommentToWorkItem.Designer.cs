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
            this.SuspendLayout();
            // 
            // addCommentButton
            // 
            this.addCommentButton.Location = new System.Drawing.Point(37, 931);
            this.addCommentButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.addCommentButton.Name = "addCommentButton";
            this.addCommentButton.Size = new System.Drawing.Size(371, 55);
            this.addCommentButton.TabIndex = 21;
            this.addCommentButton.Text = "Add comment";
            this.addCommentButton.UseVisualStyleBackColor = true;
            this.addCommentButton.Click += new System.EventHandler(this.addCommentButton_Click);
            // 
            // addAttachmentsToCommentRadio
            // 
            this.addAttachmentsToCommentRadio.AutoSize = true;
            this.addAttachmentsToCommentRadio.Location = new System.Drawing.Point(432, 938);
            this.addAttachmentsToCommentRadio.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.addAttachmentsToCommentRadio.Name = "addAttachmentsToCommentRadio";
            this.addAttachmentsToCommentRadio.Size = new System.Drawing.Size(261, 36);
            this.addAttachmentsToCommentRadio.TabIndex = 19;
            this.addAttachmentsToCommentRadio.TabStop = true;
            this.addAttachmentsToCommentRadio.Text = "withAttachments";
            this.addAttachmentsToCommentRadio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 32);
            this.label5.TabIndex = 20;
            this.label5.Text = "Work Item";
            // 
            // workItemsListComboBox
            // 
            this.workItemsListComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.workItemsListComboBox.FormattingEnabled = true;
            this.workItemsListComboBox.Location = new System.Drawing.Point(37, 90);
            this.workItemsListComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.workItemsListComboBox.Name = "workItemsListComboBox";
            this.workItemsListComboBox.Size = new System.Drawing.Size(564, 39);
            this.workItemsListComboBox.TabIndex = 17;
            this.workItemsListComboBox.DrawItem += this.workItemsListComboBox_DrawItem;
            // 
            // commentTextBox
            // 
            this.commentTextBox.BodyBackgroundColor = System.Drawing.Color.White;
            this.commentTextBox.BodyHtml = null;
            this.commentTextBox.BodyText = null;
            this.commentTextBox.DocumentText = resources.GetString("commentTextBox.DocumentText");
            this.commentTextBox.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.commentTextBox.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.commentTextBox.FontName = null;
            this.commentTextBox.FontSize = LiveSwitch.TextControl.FontSize.NA;
            this.commentTextBox.Html = null;
            this.commentTextBox.Location = new System.Drawing.Point(37, 218);
            this.commentTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(1720, 676);
            this.commentTextBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "Description";
            // 
            // AddCommentToWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 1013);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.addCommentButton);
            this.Controls.Add(this.addAttachmentsToCommentRadio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.workItemsListComboBox);
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
    }
}