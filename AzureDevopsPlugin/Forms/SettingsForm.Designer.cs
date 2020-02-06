namespace AzureDevopsPlugin.Forms
{
    partial class SettingsForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.orgNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customCategoryFieldTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.workItemTypeTextBox = new System.Windows.Forms.TextBox();
            this.projectNameTextBox = new System.Windows.Forms.MaskedTextBox();
            this.patTokenTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.defaultCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.reloadCustomFields = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveButton.Location = new System.Drawing.Point(77, 608);
            this.saveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(1344, 55);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // orgNameTextBox
            // 
            this.orgNameTextBox.Location = new System.Drawing.Point(339, 95);
            this.orgNameTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.orgNameTextBox.Name = "orgNameTextBox";
            this.orgNameTextBox.Size = new System.Drawing.Size(1039, 38);
            this.orgNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Organization Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 281);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "PAT token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Project Name";
            // 
            // customCategoryFieldTextBox
            // 
            this.customCategoryFieldTextBox.Location = new System.Drawing.Point(339, 355);
            this.customCategoryFieldTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.customCategoryFieldTextBox.Name = "customCategoryFieldTextBox";
            this.customCategoryFieldTextBox.Size = new System.Drawing.Size(1039, 38);
            this.customCategoryFieldTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 355);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category field name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Work Item Type";
            // 
            // workItemTypeTextBox
            // 
            this.workItemTypeTextBox.Location = new System.Drawing.Point(339, 427);
            this.workItemTypeTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.workItemTypeTextBox.Name = "workItemTypeTextBox";
            this.workItemTypeTextBox.Size = new System.Drawing.Size(1039, 38);
            this.workItemTypeTextBox.TabIndex = 5;
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(339, 186);
            this.projectNameTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(1039, 38);
            this.projectNameTextBox.TabIndex = 2;
            // 
            // patTokenTextBox
            // 
            this.patTokenTextBox.Location = new System.Drawing.Point(339, 274);
            this.patTokenTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.patTokenTextBox.Name = "patTokenTextBox";
            this.patTokenTextBox.PasswordChar = '*';
            this.patTokenTextBox.Size = new System.Drawing.Size(1039, 38);
            this.patTokenTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 501);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Default category";
            // 
            // defaultCategoryComboBox
            // 
            this.defaultCategoryComboBox.Enabled = false;
            this.defaultCategoryComboBox.FormattingEnabled = true;
            this.defaultCategoryComboBox.Location = new System.Drawing.Point(339, 501);
            this.defaultCategoryComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.defaultCategoryComboBox.Name = "defaultCategoryComboBox";
            this.defaultCategoryComboBox.Size = new System.Drawing.Size(852, 39);
            this.defaultCategoryComboBox.TabIndex = 6;
            // 
            // reloadCustomFields
            // 
            this.reloadCustomFields.Location = new System.Drawing.Point(1227, 503);
            this.reloadCustomFields.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reloadCustomFields.Name = "reloadCustomFields";
            this.reloadCustomFields.Size = new System.Drawing.Size(157, 48);
            this.reloadCustomFields.TabIndex = 14;
            this.reloadCustomFields.Text = "reload";
            this.reloadCustomFields.UseVisualStyleBackColor = true;
            this.reloadCustomFields.Click += new System.EventHandler(this.reloadCustomFields_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 689);
            this.Controls.Add(this.reloadCustomFields);
            this.Controls.Add(this.defaultCategoryComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.patTokenTextBox);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.workItemTypeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customCategoryFieldTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orgNameTextBox);
            this.Controls.Add(this.saveButton);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "SettingsForm";
            this.Text = "Edit Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox orgNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customCategoryFieldTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox workItemTypeTextBox;
        private System.Windows.Forms.MaskedTextBox projectNameTextBox;
        private System.Windows.Forms.TextBox patTokenTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox defaultCategoryComboBox;
        private System.Windows.Forms.Button reloadCustomFields;
    }
}