using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;
using System.Drawing;

namespace AzureDevopsPlugin.Models
{
    public class WorkItem
    {
        private static readonly HashSet<string> _ignoreStates = new HashSet<string> { "closed" };

        public static Dictionary<string, KeyValuePair<string, Color>> States { get; set; } = new Dictionary<string, KeyValuePair<string, Color>>();
        public static List<string> CategoriesBySource { get; set; } = new List<string>();
        public static List<string> CategoriesByComplexity { get; set; } = new List<string>();
        public static string CategoryBySourceReferenceName { get; set; }
        public static string CategoryByComplexityReferenceName { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string State { get; set; }

        public string Complexity { get; set; }

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
                    if (_ignoreStates.Contains(state.Name.ToLower()))
                    {
                        continue;
                    }

                    States[state.Name.ToLower()] = new KeyValuePair<string, Color>(state.Name, (Color)colorConverter.ConvertFromString("#" + state.Color));
                }
            }
        }
    }
}
