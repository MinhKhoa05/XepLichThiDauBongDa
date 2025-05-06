using System;
using System.Windows.Forms;
using BUS.BUSs;

namespace GUI.Forms
{
    public partial class FrmUserInfo : Form
    {
        public FrmUserInfo()
        {
            InitializeComponent();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            txtAccountID.Text = FrmMain.Account.AccountID;

            switch (FrmMain.Account.Role)
            {
                case "Admin":
                    txtUserName.Text = FrmMain.Account.UserName;
                    break;
                case "Referee":
                    txtUserName.Text = (new RefereeBUS()).GetById(FrmMain.Account.AccountID).RefereeName;
                    break;
                case "Team":
                    txtUserName.Text = (new TeamBUS()).GetById(FrmMain.Account.AccountID).TeamName;
                    break;
            }

            txtRole.Text = FrmMain.Account.Role;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            using (var formChangePass = new FrmChangePass(FrmMain.Account))
            {
                formChangePass.ShowDialog();
                this.Hide();
            }
        }
    }
}