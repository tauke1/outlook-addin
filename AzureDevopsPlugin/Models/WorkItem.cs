using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsPlugin.Models
{
    public class WorkItem
    {
        static Dictionary<string, Color> StatesWithColors = new Dictionary<string, System.Drawing.Color>
        {
            { "new", Color.FromArgb(173,172,174) },
            { "in irogress", Color.FromArgb(40,102,148) },
            { "under monitoring", Color.FromArgb(143,170,161) },
            { "on hold", Color.FromArgb(238,237,86) },
            { "resolved", Color.FromArgb(161,185,103) },
            { "closed", Color.FromArgb(84,140,79) }
        };

        public int Id { get; set; }

        public string Title { get; set; }

        public string State { get; set; }

        public string Url { get; set; }
        public Color StateColor { get {
                var stateLower = State != null ? State.ToLower() : string.Empty;
                return StatesWithColors.ContainsKey(stateLower) ? StatesWithColors[stateLower] : Color.White;
            }
        }
        public override string ToString()
        {
            return Id + " " + Title;
        }
    }
}
