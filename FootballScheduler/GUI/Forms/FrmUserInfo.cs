using System;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;

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
            txtAccountID.Text = _account.AccountID;

            switch (_account.Role)
            {
                case "Admin":
                    txtUserName.Text = _account.UserName;
                    break;
                case "Referee":
                    txtUserName.Text = (new RefereeBUS()).GetById(_account.AccountID).RefereeName;
                    break;
                case "Team":
                    txtUserName.Text = (new TeamBUS()).GetById(_account.AccountID).TeamName;
                    break;
            }

            txtRole.Text = _account.Role;
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