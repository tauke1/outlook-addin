using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
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
        static Dictionary<string, KeyValuePair<string, Color>> States = new Dictionary<string, KeyValuePair<string,Color>>();

        public int Id { get; set; }

        public string Title { get; set; }

        public string State { get; set; }

        public string Url { get; set; }
        public Color StateColor { get {
                var stateLower = State != null ? State.ToLower() : string.Empty;
                return States.ContainsKey(stateLower) ? States[stateLower].Value : Color.White;
            }
        }
        public override string ToString()
        {
            return Id + " " + Title;
        }

        public static void SetStates(List<WorkItemStateColor> stateColors)
        {
            States.Clear();
            var colorConverter = new ColorConverter();
            if (stateColors?.Count > 0)
            {
                foreach (var state in stateColors)
                {
                    States[state.Name.ToLower()] = new KeyValuePair<string, Color>(state.Name, (Color)colorConverter.ConvertFromString("#" + state.Color));
                }
            }
        }

        public static Dictionary<string, KeyValuePair<string, Color>> GetStates()
        {
            return States;
        }
    }
}
