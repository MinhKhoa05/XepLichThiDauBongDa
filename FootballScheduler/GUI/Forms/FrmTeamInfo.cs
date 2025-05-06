using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using GUI.Helpers;
using BUS.BUSs;

namespace GUI.Forms
{
    public partial class FrmTeamInfo : Form
    {
        private readonly TeamDTO _originalTeam;

        public FrmTeamInfo(TeamDTO team = null)
        {
            InitializeComponent();
            _originalTeam = team;
        }

        private void FrmTeamInfo_Load(object sender, EventArgs e)
        {
            if (_originalTeam != null)
            {
                DisplayTeamInfo(_originalTeam);
            }
            else
            {
                txtTeamName.Text = "";
                txtCoachName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                picBoxLogo.Image = null;
                cbHomeStadium.SelectedIndex = -1; // Chọn sân nhà mặc định
            }

            LoadComboBox();

        }

        private void DisplayTeamInfo(TeamDTO team)
        {
            txtTeamName.Text = team.TeamName;
            txtCoachName.Text = team.CoachName;
            txtEmail.Text = team.Email;
            txtPhone.Text = team.Phone;

            if (!string.IsNullOrEmpty(team.LogoURL))
            {
                picBoxLogo.Image = ImageHelper.GetImageFromFile(team.LogoURL, 284, 270);
            }
        }

        private void LoadComboBox()
        {
            cbHomeStadium.DataSource = new StadiumBUS().GetAll(); ;
            cbHomeStadium.DisplayMember = "StadiumName";
            cbHomeStadium.ValueMember = "StadiumID";

            if (_originalTeam != null)
                cbHomeStadium.SelectedValue = _originalTeam.HomeStadiumID;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            var updatedTeam = CreateTeamDTO();

            if (!ValidateTeam(updatedTeam))
            {
                return;
            }


            this.Tag = updatedTeam;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateForm()
        {
            // Kiểm tra tên đội bóng
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                MyMessageBox.ShowError("Tên đội bóng không được để trống.");
                txtTeamName.Focus();
                return false;
            }

            // Kiểm tra huấn luyện viên
            if (string.IsNullOrWhiteSpace(txtCoachName.Text))
            {
                MyMessageBox.ShowError("Tên huấn luyện viên không được để trống.");
                txtCoachName.Focus();
                return false;
            }

            // Kiểm tra email hợp lệ
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains('@'))
            {
                MyMessageBox.ShowError("Email không hợp lệ.");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private TeamDTO CreateTeamDTO()
        {
            return new TeamDTO
            {
                TeamID = _originalTeam?.TeamID,
                TeamName = txtTeamName.Text.Trim(),
                CoachName = txtCoachName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                LogoURL = ImageHelper.SaveImageToFile("TeamLogo", txtTeamName.Text, picBoxLogo.Image),
                HomeStadiumID = ((StadiumDTO)cbHomeStadium.SelectedItem)?.StadiumID
            };
        }

        private bool ValidateTeam(TeamDTO updatedTeam)
        {
            if (!ValidatorHelper.TryValidate(updatedTeam, out var error))
            {
                MyMessageBox.ShowError(error);
                txtTeamName.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            picBoxLogo.Image = ImageHelper.SelectImageFromFile();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số hoặc ký tự đặc biệt như dấu +, - trong số điện thoại
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void btnAddStadium_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmStadiumInfo())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string newStadiumId = frm.Tag as string;
                    cbHomeStadium.DataSource = new StadiumBUS().GetAll();
                    cbHomeStadium.DisplayMember = "StadiumName";
                    cbHomeStadium.ValueMember = "StadiumID";
                    cbHomeStadium.SelectedValue = newStadiumId;
                }
            }
        }
    }
}
