﻿namespace AzureDevopsPlugin.Forms
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
            this.categoryBySourceFieldTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.workItemTypeTextBox = new System.Windows.Forms.TextBox();
            this.projectNameTextBox = new System.Windows.Forms.MaskedTextBox();
            this.patTokenTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.defaultCategoryBySourceComboBox = new System.Windows.Forms.ComboBox();
            this.reloadCustomFields = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.categoryByComplexityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveButton.Location = new System.Drawing.Point(78, 617);
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
            this.orgNameTextBox.Location = new System.Drawing.Point(386, 95);
            this.orgNameTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.orgNameTextBox.Name = "orgNameTextBox";
            this.orgNameTextBox.Size = new System.Drawing.Size(1039, 38);
            this.orgNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Organization Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "PAT token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Project Name";
            // 
            // categoryBySourceFieldTextBox
            // 
            this.categoryBySourceFieldTextBox.Location = new System.Drawing.Point(386, 304);
            this.categoryBySourceFieldTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.categoryBySourceFieldTextBox.Name = "categoryBySourceFieldTextBox";
            this.categoryBySourceFieldTextBox.Size = new System.Drawing.Size(1039, 38);
            this.categoryBySourceFieldTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category by source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 383);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Work Item Type";
            // 
            // workItemTypeTextBox
            // 
            this.workItemTypeTextBox.Location = new System.Drawing.Point(389, 377);
            this.workItemTypeTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.workItemTypeTextBox.Name = "workItemTypeTextBox";
            this.workItemTypeTextBox.Size = new System.Drawing.Size(1039, 38);
            this.workItemTypeTextBox.TabIndex = 5;
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(386, 165);
            this.projectNameTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(1039, 38);
            this.projectNameTextBox.TabIndex = 2;
            // 
            // patTokenTextBox
            // 
            this.patTokenTextBox.Location = new System.Drawing.Point(386, 235);
            this.patTokenTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.patTokenTextBox.Name = "patTokenTextBox";
            this.patTokenTextBox.PasswordChar = '*';
            this.patTokenTextBox.Size = new System.Drawing.Size(1039, 38);
            this.patTokenTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 532);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(351, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Default category by source";
            // 
            // defaultCategoryBySourceComboBox
            // 
            this.defaultCategoryBySourceComboBox.Enabled = false;
            this.defaultCategoryBySourceComboBox.FormattingEnabled = true;
            this.defaultCategoryBySourceComboBox.Location = new System.Drawing.Point(392, 525);
            this.defaultCategoryBySourceComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.defaultCategoryBySourceComboBox.Name = "defaultCategoryBySourceComboBox";
            this.defaultCategoryBySourceComboBox.Size = new System.Drawing.Size(852, 39);
            this.defaultCategoryBySourceComboBox.TabIndex = 6;
            // 
            // reloadCustomFields
            // 
            this.reloadCustomFields.Location = new System.Drawing.Point(1271, 519);
            this.reloadCustomFields.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reloadCustomFields.Name = "reloadCustomFields";
            this.reloadCustomFields.Size = new System.Drawing.Size(157, 48);
            this.reloadCustomFields.TabIndex = 14;
            this.reloadCustomFields.Text = "reload";
            this.reloadCustomFields.UseVisualStyleBackColor = true;
            this.reloadCustomFields.Click += new System.EventHandler(this.reloadCustomFields_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 455);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(309, 32);
            this.label7.TabIndex = 16;
            this.label7.Text = "Category by complexity";
            // 
            // categoryByComplexityTextBox
            // 
            this.categoryByComplexityTextBox.Location = new System.Drawing.Point(389, 449);
            this.categoryByComplexityTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.categoryByComplexityTextBox.Name = "categoryByComplexityTextBox";
            this.categoryByComplexityTextBox.Size = new System.Drawing.Size(1039, 38);
            this.categoryByComplexityTextBox.TabIndex = 15;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 702);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.categoryByComplexityTextBox);
            this.Controls.Add(this.reloadCustomFields);
            this.Controls.Add(this.defaultCategoryBySourceComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.patTokenTextBox);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.workItemTypeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryBySourceFieldTextBox);
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
        private System.Windows.Forms.TextBox categoryBySourceFieldTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox workItemTypeTextBox;
        private System.Windows.Forms.MaskedTextBox projectNameTextBox;
        private System.Windows.Forms.TextBox patTokenTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox defaultCategoryBySourceComboBox;
        private System.Windows.Forms.Button reloadCustomFields;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox categoryByComplexityTextBox;
    }
}