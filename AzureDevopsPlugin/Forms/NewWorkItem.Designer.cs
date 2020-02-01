namespace AzureDevopsPlugin.Forms
{
    partial class NewWorkItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWorkItem));
            this.workItemCreateBtn = new System.Windows.Forms.Button();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new LiveSwitch.TextControl.Editor();
            this.label3 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.setOriginalBodyBtn = new System.Windows.Forms.Button();
            this.includeAttachmentsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // workItemCreateBtn
            // 
            this.workItemCreateBtn.Location = new System.Drawing.Point(22, 408);
            this.workItemCreateBtn.Name = "workItemCreateBtn";
            this.workItemCreateBtn.Size = new System.Drawing.Size(168, 26);
            this.workItemCreateBtn.TabIndex = 13;
            this.workItemCreateBtn.Text = "Create Work Item";
            this.workItemCreateBtn.UseVisualStyleBackColor = true;
            this.workItemCreateBtn.Click += new System.EventHandler(this.workItemCreateBtn_Click);
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Location = new System.Drawing.Point(532, 36);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(258, 21);
            this.categoriesComboBox.TabIndex = 9;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Enabled = false;
            this.titleTextBox.Location = new System.Drawing.Point(22, 36);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(463, 20);
            this.titleTextBox.TabIndex = 10;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Category";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BodyBackgroundColor = System.Drawing.Color.White;
            this.descriptionTextBox.BodyHtml = null;
            this.descriptionTextBox.BodyText = null;
            this.descriptionTextBox.DocumentText = resources.GetString("descriptionTextBox.DocumentText");
            this.descriptionTextBox.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.descriptionTextBox.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.descriptionTextBox.FontSize = LiveSwitch.TextControl.FontSize.Three;
            this.descriptionTextBox.Html = null;
            this.descriptionTextBox.Location = new System.Drawing.Point(22, 92);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(767, 287);
            this.descriptionTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Description";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(708, 408);
            this.resetButton.Margin = new System.Windows.Forms.Padding(1);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(81, 26);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset fields";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // setOriginalBodyBtn
            // 
            this.setOriginalBodyBtn.Location = new System.Drawing.Point(543, 408);
            this.setOriginalBodyBtn.Name = "setOriginalBodyBtn";
            this.setOriginalBodyBtn.Size = new System.Drawing.Size(152, 26);
            this.setOriginalBodyBtn.TabIndex = 18;
            this.setOriginalBodyBtn.Text = "Use original message body";
            this.setOriginalBodyBtn.UseVisualStyleBackColor = true;
            this.setOriginalBodyBtn.Click += new System.EventHandler(this.setOriginalBodyBtn_Click);
            // 
            // includeAttachmentsCheckBox
            // 
            this.includeAttachmentsCheckBox.AutoSize = true;
            this.includeAttachmentsCheckBox.Location = new System.Drawing.Point(208, 414);
            this.includeAttachmentsCheckBox.Name = "includeAttachmentsCheckBox";
            this.includeAttachmentsCheckBox.Size = new System.Drawing.Size(121, 17);
            this.includeAttachmentsCheckBox.TabIndex = 19;
            this.includeAttachmentsCheckBox.Text = "include attachments";
            this.includeAttachmentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 452);
            this.Controls.Add(this.includeAttachmentsCheckBox);
            this.Controls.Add(this.setOriginalBodyBtn);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.workItemCreateBtn);
            this.Controls.Add(this.categoriesComboBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "NewWorkItem";
            this.Text = "NewWorkItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button workItemCreateBtn;
        private System.Windows.Forms.ComboBox categoriesComboBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private LiveSwitch.TextControl.Editor descriptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button setOriginalBodyBtn;
        private System.Windows.Forms.CheckBox includeAttachmentsCheckBox;
    }
}