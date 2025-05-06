using System;
using System.Drawing;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtPass.KeyPress += (s, e) => EnterToLogin(e);
            txtUserName.KeyPress += (s, e) => EnterToLogin(e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MyMessageBox.ShowError("Vui lòng điền đầy đủ thông tin!");
                txtUserName.Focus();
                return;
            }

            try
            {
                AccountDTO account = (new AccountBUS()).Login(username, password);

                switch (account.Role)
                {
                    case "Admin":
                        username = "Quản trị viên";
                        break;
                    case "Referee":
                        username = (new RefereeBUS()).GetById(account.AccountID).RefereeName;
                        break;
                    case "Team":
                        username = (new TeamBUS()).GetById(account.AccountID).TeamName;
                        break;
                }

                MyMessageBox.ShowInformation($"Đăng nhập thành công\r\nXin chào {username}");

                Hide();

                using (FrmMain formMain = new FrmMain(account))
                {
                    formMain.ShowDialog();
                }

                Close();
            }
            catch (Exception ex)
            {
                txtUserName.Focus();
                MyMessageBox.ShowError(ex.Message);
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;

            btnToggle.Image = txtPass.UseSystemPasswordChar
                ? Properties.Resources.eye_show
                : Properties.Resources.eye_hide;
        }

        private void EnterToLogin(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            btnLogin.FillColor = Color.FromArgb(62, 61, 110);
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            btnLogin.FillColor = Color.FromArgb(37, 36, 100);
        }

        private void btnToggle_Enter(object sender, EventArgs e)
        {
            btnToggle.FillColor = Color.FromArgb(69, 68, 123);
        }

        private void btnToggle_Leave(object sender, EventArgs e)
        {
            btnToggle.FillColor = Color.FromArgb(37, 36, 100);
        }
    }
}