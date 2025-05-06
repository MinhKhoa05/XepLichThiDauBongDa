using System;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmChangePass : Form
    {
        private readonly AccountDTO _account;
        private readonly AccountBUS _accountBUS = new AccountBUS();

        public FrmChangePass(AccountDTO account)
        {
            InitializeComponent();
            _account = account;
        }

        private void FrmChangePass_Load(object sender, EventArgs e)
        {
            txtUsername.Text = _account.UserName;
            txtPass_old.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPass = txtPass_old.Text;
                string newPass = txtPass_new.Text;
                string confirmPass = txtConfirmPass.Text;

                ValidateInput(oldPass, newPass, confirmPass);
                ValidatePasswordRules(oldPass, newPass, confirmPass);

                _account.PasswordHash = newPass;
                _accountBUS.Update(_account);

                MyMessageBox.ShowInformation("Đổi mật khẩu thành công!");
                Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError(ex.Message);
            }
        }

        private void ValidateInput(string oldPass, string newPass, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(oldPass) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confirmPass))
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin!");
            }
        }

        private void ValidatePasswordRules(string oldPass, string newPass, string confirmPass)
        {
            if (_account.PasswordHash != oldPass)
                throw new Exception("Mật khẩu cũ không đúng!");

            if (newPass == oldPass)
                throw new Exception("Mật khẩu mới không được trùng với mật khẩu cũ!");

            if (newPass != confirmPass)
                throw new Exception("Mật khẩu mới và xác nhận không khớp!");
        }
    }
}
