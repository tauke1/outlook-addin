namespace AzureDevopsPlugin
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
            this.attachmentsRadio = new System.Windows.Forms.RadioButton();
            this.workItemCreateBtn = new System.Windows.Forms.Button();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new LiveSwitch.TextControl.Editor();
            this.label3 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attachmentsRadio
            // 
            this.attachmentsRadio.AutoSize = true;
            this.attachmentsRadio.Location = new System.Drawing.Point(544, 988);
            this.attachmentsRadio.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.attachmentsRadio.Name = "attachmentsRadio";
            this.attachmentsRadio.Size = new System.Drawing.Size(306, 36);
            this.attachmentsRadio.TabIndex = 14;
            this.attachmentsRadio.TabStop = true;
            this.attachmentsRadio.Text = "Include attachments";
            this.attachmentsRadio.UseVisualStyleBackColor = true;
            // 
            // workItemCreateBtn
            // 
            this.workItemCreateBtn.Location = new System.Drawing.Point(58, 973);
            this.workItemCreateBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.workItemCreateBtn.Name = "workItemCreateBtn";
            this.workItemCreateBtn.Size = new System.Drawing.Size(448, 62);
            this.workItemCreateBtn.TabIndex = 13;
            this.workItemCreateBtn.Text = "Create Work Item";
            this.workItemCreateBtn.UseVisualStyleBackColor = true;
            this.workItemCreateBtn.Click += new System.EventHandler(this.workItemCreateBtn_Click);
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Location = new System.Drawing.Point(1420, 87);
            this.categoriesComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(681, 39);
            this.categoriesComboBox.TabIndex = 9;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(58, 87);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(1229, 38);
            this.titleTextBox.TabIndex = 10;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1414, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
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
            this.descriptionTextBox.Location = new System.Drawing.Point(58, 220);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(2046, 685);
            this.descriptionTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "Description";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(1888, 972);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(216, 63);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset fields";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // NewWorkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2204, 1079);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.attachmentsRadio);
            this.Controls.Add(this.workItemCreateBtn);
            this.Controls.Add(this.categoriesComboBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "NewWorkItem";
            this.Text = "NewWorkItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton attachmentsRadio;
        private System.Windows.Forms.Button workItemCreateBtn;
        private System.Windows.Forms.ComboBox categoriesComboBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private LiveSwitch.TextControl.Editor descriptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetButton;
    }
}