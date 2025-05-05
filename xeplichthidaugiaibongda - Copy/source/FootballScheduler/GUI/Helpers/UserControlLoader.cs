using System.Windows.Forms;

namespace GUI.Helpers
{
    public static class UserControlLoader
    {
        /// <summary>
        /// Hiển thị UserControl vào panel đích
        /// </summary>
        public static void DisplayUserControl(Panel targetPanel, UserControl control)
        {
            targetPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(control);
            control.BringToFront();
        }
    }
}
