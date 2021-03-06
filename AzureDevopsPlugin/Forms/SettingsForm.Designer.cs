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
            this.saveButton.Location = new System.Drawing.Point(29, 259);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(504, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // orgNameTextBox
            // 
            this.orgNameTextBox.Location = new System.Drawing.Point(145, 40);
            this.orgNameTextBox.Name = "orgNameTextBox";
            this.orgNameTextBox.Size = new System.Drawing.Size(392, 20);
            this.orgNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Organization Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "PAT token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Project Name";
            // 
            // categoryBySourceFieldTextBox
            // 
            this.categoryBySourceFieldTextBox.Location = new System.Drawing.Point(145, 127);
            this.categoryBySourceFieldTextBox.Name = "categoryBySourceFieldTextBox";
            this.categoryBySourceFieldTextBox.Size = new System.Drawing.Size(392, 20);
            this.categoryBySourceFieldTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category by source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Work Item Type";
            // 
            // workItemTypeTextBox
            // 
            this.workItemTypeTextBox.Location = new System.Drawing.Point(146, 158);
            this.workItemTypeTextBox.Name = "workItemTypeTextBox";
            this.workItemTypeTextBox.Size = new System.Drawing.Size(392, 20);
            this.workItemTypeTextBox.TabIndex = 5;
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(145, 69);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(392, 20);
            this.projectNameTextBox.TabIndex = 2;
            // 
            // patTokenTextBox
            // 
            this.patTokenTextBox.Location = new System.Drawing.Point(145, 99);
            this.patTokenTextBox.Name = "patTokenTextBox";
            this.patTokenTextBox.PasswordChar = '*';
            this.patTokenTextBox.Size = new System.Drawing.Size(392, 20);
            this.patTokenTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Default category by source";
            // 
            // defaultCategoryBySourceComboBox
            // 
            this.defaultCategoryBySourceComboBox.Enabled = false;
            this.defaultCategoryBySourceComboBox.FormattingEnabled = true;
            this.defaultCategoryBySourceComboBox.Location = new System.Drawing.Point(147, 220);
            this.defaultCategoryBySourceComboBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.defaultCategoryBySourceComboBox.Name = "defaultCategoryBySourceComboBox";
            this.defaultCategoryBySourceComboBox.Size = new System.Drawing.Size(322, 21);
            this.defaultCategoryBySourceComboBox.TabIndex = 7;
            // 
            // reloadCustomFields
            // 
            this.reloadCustomFields.Location = new System.Drawing.Point(477, 218);
            this.reloadCustomFields.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.reloadCustomFields.Name = "reloadCustomFields";
            this.reloadCustomFields.Size = new System.Drawing.Size(59, 20);
            this.reloadCustomFields.TabIndex = 14;
            this.reloadCustomFields.Text = "reload";
            this.reloadCustomFields.UseVisualStyleBackColor = true;
            this.reloadCustomFields.Click += new System.EventHandler(this.reloadCustomFields_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Category by complexity";
            // 
            // categoryByComplexityTextBox
            // 
            this.categoryByComplexityTextBox.Location = new System.Drawing.Point(146, 188);
            this.categoryByComplexityTextBox.Name = "categoryByComplexityTextBox";
            this.categoryByComplexityTextBox.Size = new System.Drawing.Size(392, 20);
            this.categoryByComplexityTextBox.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 294);
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