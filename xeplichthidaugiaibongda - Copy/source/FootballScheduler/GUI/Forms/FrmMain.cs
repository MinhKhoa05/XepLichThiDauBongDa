using System;
using System.Windows.Forms;
using GUI.Helpers;
using GUI.UserControls;

namespace GUI.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Đặt UcSidebar vào panel SidebarMenu
            UserControlLoader.DisplayUserControl(pnlControl, new UcHome()); // Hiển thị UcHome khi nhấp vào logo
            UserControlLoader.DisplayUserControl(pnlSidebarMenu, new UcSidebar(pnlControl));
        }

        private void picBoxLogo_Click(object sender, EventArgs e)
        {
            UserControlLoader.DisplayUserControl(pnlControl, new UcHome()); // Hiển thị UcHome khi nhấp vào logo
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            using (var loginForm = new FrmLogin())
            {
                loginForm.ShowDialog();
            }
            Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            using (var formProfile = new FrmUserInfo(new DTO.AccountDTO(1, "Khoa", "123456")))
            {
                formProfile.ShowDialog();
            }
        }
    }
}
