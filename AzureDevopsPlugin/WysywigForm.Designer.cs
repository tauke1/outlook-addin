namespace AzureDevopsPlugin
{
    partial class WysywigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WysywigForm));
            this.editor = new LiveSwitch.TextControl.Editor();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.BodyBackgroundColor = System.Drawing.Color.White;
            this.editor.BodyHtml = null;
            this.editor.BodyText = null;
            this.editor.DocumentText = resources.GetString("editor.DocumentText");
            this.editor.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor.FontName = null;
            this.editor.FontSize = LiveSwitch.TextControl.FontSize.NA;
            this.editor.Html = null;
            this.editor.Location = new System.Drawing.Point(12, 12);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(776, 386);
            this.editor.TabIndex = 0;
            
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(205, 415);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(377, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // WysywigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editor);
            this.Name = "WysywigForm";
            this.Text = "WysywigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveSwitch.TextControl.Editor editor;
        private System.Windows.Forms.Button saveButton;
    }
}