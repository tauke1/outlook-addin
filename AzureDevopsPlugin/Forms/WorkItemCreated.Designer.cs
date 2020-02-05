namespace AzureDevopsPlugin.Forms
{
    partial class WorkItemCreated
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
            this.openBrowser = new System.Windows.Forms.Button();
            this.workItemLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openBrowser
            // 
            this.openBrowser.Location = new System.Drawing.Point(258, 332);
            this.openBrowser.Name = "openBrowser";
            this.openBrowser.Size = new System.Drawing.Size(273, 55);
            this.openBrowser.TabIndex = 0;
            this.openBrowser.Text = "Open in browser";
            this.openBrowser.UseVisualStyleBackColor = true;
            this.openBrowser.Click += new System.EventHandler(this.openBrowser_Click);
            // 
            // workItemLabel
            // 
            this.workItemLabel.AutoSize = true;
            this.workItemLabel.Location = new System.Drawing.Point(60, 79);
            this.workItemLabel.Name = "workItemLabel";
            this.workItemLabel.Size = new System.Drawing.Size(199, 32);
            this.workItemLabel.TabIndex = 1;
            this.workItemLabel.Text = "workItemLabel";
            // 
            // WorkItemCreated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.workItemLabel);
            this.Controls.Add(this.openBrowser);
            this.Name = "WorkItemCreated";
            this.Text = "Work Item successfully created";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBrowser;
        private System.Windows.Forms.Label workItemLabel;
    }
}