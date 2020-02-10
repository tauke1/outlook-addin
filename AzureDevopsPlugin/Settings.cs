using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevopsPlugin
{
    public sealed class Settings : ApplicationSettingsBase
    {
        private static Settings _settings;

        public static Settings settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new Settings();
                }
                return _settings;
            }
        }

        private Settings()
        {
        }

        [UserScopedSetting()]
        public string OrgName
        {
            get { return (string)this["OrgName"]; }
            set { this["OrgName"] = value; }
        }

        [UserScopedSetting()]
        public string ProjectName
        {
            get { return (string)(this["ProjectName"]); }
            set { this["ProjectName"] = value; }
        }

        [UserScopedSetting()]
        public string PatToken
        {
            get { return (string)this["PatToken"]; }
            set { this["PatToken"] = value; }
        }

        [UserScopedSetting()]
        public string WorkItemType
        {
            get { return (string)this["WorkItemType"]; }
            set { this["WorkItemType"] = value; }
        }

        [UserScopedSetting()]
        public string CategoryBySourceField
        {
            get { return (string)this["CategoryBySourceField"]; }
            set { this["CategoryBySourceField"] = value; }
        }

        [UserScopedSetting()]
        public string CategoryByComplexityField
        {
            get { return (string)this["CategoryByComplexityField"]; }
            set { this["CategoryByComplexityField"] = value; }
        }

        [UserScopedSetting()]
        public string CategoryBySourceDefaultValue {
            get { return (string)this["CategoryBySourceDefaultValue"]; }
            set { this["CategoryBySourceDefaultValue"] = value; }
        }

        public string ProjectURL { get { return "https://github.com/tauke1/outlook-addin"; } }

        public bool Validate(bool showMessage = true)
        {
            var errorMessage = "";
            if (string.IsNullOrEmpty(this.WorkItemType))
            {
                errorMessage += "please fill Work Item Type field in settings\n";
            }

            if (string.IsNullOrEmpty(this.PatToken))
            {
                errorMessage += "please fill PAT token field in settings\n";
            }

            if (string.IsNullOrEmpty(this.ProjectName))
            {
                errorMessage += "please fill project Name field in settings\n";
            }

            if (string.IsNullOrEmpty(this.OrgName))
            {
                errorMessage += "please fill organization name field in settings\n";
            }

            if (string.IsNullOrEmpty(this.CategoryBySourceField))
            {
                errorMessage += "please fill category by source field in settings\n";
            }

            if (string.IsNullOrEmpty(this.CategoryByComplexityField))
            {
                errorMessage += "please fill category by complexity field in settings\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                if (showMessage)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            return true;
        }

        public delegate void SettingsChangedFunc();
        private SettingsChangedFunc SettingsChanged;

        public void SendSettingsChangedNotification()
        {
            SettingsChanged?.Invoke();
        }

        public void SetSettingsChangedNotification(SettingsChangedFunc func)
        {
            SettingsChanged = func;
        }
    }
}
