using System;
using System.Windows.Forms;
using DTO;
using BUS.Others;

namespace GUI.Forms
{
    public partial class FrmUserInfo : Form
    {
        private AccountDTO _account;

        public FrmUserInfo(AccountDTO account)
        {
            InitializeComponent();
            _account = account;
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            txtUserName.Text = _account.UserName;
            txtRole.Text = _account.Role;
            txtPass.Text = _account.PasswordHash;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            using (var formChangePass = new FrmChangePass(_account))
            {
                formChangePass.ShowDialog();
                this.Hide(); 
            }
        }
    }
}