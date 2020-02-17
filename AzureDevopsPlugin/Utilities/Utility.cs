using System.Drawing;
using System.Windows.Forms;

namespace AzureDevopsPlugin.Utilities
{
    /// <summary>
    /// Main objective utility functions
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Move form to center of outlook app and then show it
        /// </summary>
        /// <param name="form">form</param>
        public static void MoveFormToCenterAndShow(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            dynamic window = Globals.ThisAddIn.Application.ActiveWindow();
            form.Location = new Point(window.Left + ((window.Width - form.Width) / 2), window.Top + ((window.Height - form.Height) / 2));
            form.Show();
        }
    }
}
