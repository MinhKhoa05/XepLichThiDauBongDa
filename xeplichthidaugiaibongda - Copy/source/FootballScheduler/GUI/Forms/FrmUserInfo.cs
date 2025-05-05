using System;
using System.Windows.Forms;
using BUS.Others;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI.Forms
{
    public partial class FrmUserInfo : Form
    {
        private readonly AccountDTO _account;

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
            using (var formChangePass = new FrmChangePass())
            {
                formChangePass.ShowDialog();
                this.Hide(); 
            }
        }
    }
}