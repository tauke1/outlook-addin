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
            get {
                if(_settings == null)
                {
                    _settings = new Settings();
                }
                return _settings;
            }
        }

        private Settings()
        {
        }



        public static List<string> CategoriesList = new List<string>{
            "Check-ins verification",
            "Code review",
            "Communication",
            "Developer support",
            "Development",
            "Infrastructure maintenance",
            "Integrations",
            "Investigation",
            "Monitoring",
            "Operational work (default)",
            "Reporting",
            "Testing"
        };

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
        public List<string> Categories
        {
            get { return (List<string>)this["Categories"];  }
            set { this["Categories"] = value; }
        }

        public bool Validate()
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

            if (this.Categories.Count == 0)
            {
                errorMessage += "please fill categories field in settings\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }
    }
}
