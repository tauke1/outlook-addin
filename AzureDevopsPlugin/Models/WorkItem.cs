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
            { "New", Color.FromArgb(173,172,174) },
            { "In Progress", Color.FromArgb(40,102,148) },
            { "Under Monitoring", Color.FromArgb(143,170,161) },
            { "On Hold", Color.FromArgb(238,237,86) },
            { "Resolved", Color.FromArgb(161,185,103) },
            { "Closed", Color.FromArgb(84,140,79) }
        };

        public int Id { get; set; }

        public string Title { get; set; }

        public string State { get; set; }

        public string Url { get; set; }
        public Color StateColor { get {
                return StatesWithColors.ContainsKey(State) ? StatesWithColors[State] : Color.White;
            }
        }
        public override string ToString()
        {
            return Id + " " + Title;
        }
    }
}
