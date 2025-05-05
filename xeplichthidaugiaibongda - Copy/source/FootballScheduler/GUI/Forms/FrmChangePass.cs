using System;
using System.Drawing;
using System.Windows.Forms;
using BUS.Others;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmChangePass: Form
    {
        private AccountBUS _accountBUS = new AccountBUS();
        public AccountDTO Account { get; private set; }

        public FrmChangePass()
        {
            InitializeComponent();
        }

        private void FrmChangePass_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string oldPassword = txtPass_old.Text;
                string newPassword = txtPass_new.Text;
                string confirmPassword = txtConfirmPass.Text;

                // Validate input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPassword) ||
                    string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MyMessageBox.ShowError("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MyMessageBox.ShowError("Mật khẩu mới và xác nhận mật khẩu không khớp!");
                    return;
                }

                // Kiểm tra mật khẩu cũ
                string currentPassword = _accountBUS.GetPasswordByUsername(username);

                if (currentPassword == null)
                {
                    MyMessageBox.ShowError("Tài khoản không tồn tại!");
                    //MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentPassword != oldPassword)
                {
                    MyMessageBox.ShowError("Mật khẩu cũ không đúng!");
                    //MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thực hiện cập nhật mật khẩu
                _accountBUS.UpdatePassword(username, newPassword);

                // Cập nhật lại _account để phản ánh mật khẩu mới
                Account = _accountBUS.GetAccountForLogin(username, newPassword);

                MyMessageBox.ShowInformation("Đổi mật khẩu thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError(ex.Message);
                //MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
