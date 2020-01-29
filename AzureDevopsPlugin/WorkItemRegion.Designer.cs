using Microsoft.Office.Interop.Outlook;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class WorkItemRegion : Microsoft.Office.Tools.Outlook.FormRegionBase
    {
        private Uri uri { get; }
        private string personalAccessToken { get; }

        public WorkItemRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            : base(Globals.Factory, formRegion)
        {
            this.InitializeComponent();
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Form Region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private static void InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest manifest, Microsoft.Office.Tools.Outlook.Factory factory)
        {
            manifest.FormRegionName = "WorkItemRegion";
            manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining;

        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editSettingsButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.addCommentBtn = new System.Windows.Forms.Button();
            this.newWorkItemBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editSettingsButton
            // 
            this.editSettingsButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.editSettingsButton.Location = new System.Drawing.Point(238, 14);
            this.editSettingsButton.Name = "editSettingsButton";
            this.editSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.editSettingsButton.TabIndex = 1;
            this.editSettingsButton.Text = "Edit Settings";
            this.editSettingsButton.UseVisualStyleBackColor = false;
            this.editSettingsButton.Click += new System.EventHandler(this.editSettingsButton_Click);
            // 
            // addCommentBtn
            // 
            this.addCommentBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addCommentBtn.Location = new System.Drawing.Point(10, 58);
            this.addCommentBtn.Name = "addCommentBtn";
            this.addCommentBtn.Size = new System.Drawing.Size(190, 23);
            this.addCommentBtn.TabIndex = 2;
            this.addCommentBtn.Text = "Add comment to existing work item";
            this.addCommentBtn.UseVisualStyleBackColor = false;
            this.addCommentBtn.Click += new System.EventHandler(this.addCommentBtn_Click);
            // 
            // newWorkItemBtn
            // 
            this.newWorkItemBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.newWorkItemBtn.Location = new System.Drawing.Point(10, 14);
            this.newWorkItemBtn.Name = "newWorkItemBtn";
            this.newWorkItemBtn.Size = new System.Drawing.Size(190, 23);
            this.newWorkItemBtn.TabIndex = 3;
            this.newWorkItemBtn.Text = "Create New Work Item";
            this.newWorkItemBtn.UseVisualStyleBackColor = false;
            this.newWorkItemBtn.Click += new System.EventHandler(this.newWorkItemBtn_Click);
            // 
            // WorkItemRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newWorkItemBtn);
            this.Controls.Add(this.addCommentBtn);
            this.Controls.Add(this.editSettingsButton);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "WorkItemRegion";
            this.Size = new System.Drawing.Size(352, 140);
            this.FormRegionShowing += new System.EventHandler(this.WorkItemRegion_FormRegionShowing);
            this.FormRegionClosed += new System.EventHandler(this.WorkItemRegion_FormRegionClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button editSettingsButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button addCommentBtn;
        private Button newWorkItemBtn;

        public partial class WorkItemRegionFactory : Microsoft.Office.Tools.Outlook.IFormRegionFactory
        {
            public event Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler FormRegionInitializing;

            private Microsoft.Office.Tools.Outlook.FormRegionManifest _Manifest;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public WorkItemRegionFactory()
            {
                this._Manifest = Globals.Factory.CreateFormRegionManifest();
                WorkItemRegion.InitializeManifest(this._Manifest, Globals.Factory);
                this.FormRegionInitializing += new Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler(this.WorkItemRegionFactory_FormRegionInitializing);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public Microsoft.Office.Tools.Outlook.FormRegionManifest Manifest
            {
                get
                {
                    return this._Manifest;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.IFormRegion Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            {
                WorkItemRegion form = new WorkItemRegion(formRegion);
                form.Factory = this;
                return form;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            byte[] Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                throw new System.NotSupportedException();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            bool Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                if (this.FormRegionInitializing != null)
                {
                    Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs cancelArgs = Globals.Factory.CreateFormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, false);
                    this.FormRegionInitializing(this, cancelArgs);
                    return !cancelArgs.Cancel;
                }
                else
                {
                    return true;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.FormRegionKindConstants Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            {
                get
                {
                    return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms;
                }
            }
        }
    }

    partial class WindowFormRegionCollection
    {
        internal WorkItemRegion WorkItemRegion
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.GetType() == typeof(WorkItemRegion))
                        return (WorkItemRegion)item;
                }
                return null;
            }
        }
    }
}
