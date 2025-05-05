using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using GUI.Helpers;
using BUS.Services;
using CORE;

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
                Logger.Instance.Log("Thông tin đội bóng không hợp lệ.", LogLevel.Warning);
                return;
            }

            var updatedTeam = CreateTeamDTO();

            if (!ValidateTeam(updatedTeam))
            {
                Logger.Instance.Log("Thông tin đội bóng không hợp lệ.", LogLevel.Warning);
                return;
            }

            Logger.Instance.Log($"Thông tin đội bóng đã được xác nhận: {updatedTeam.TeamName}");

            this.Tag = updatedTeam;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateForm()
        {
            // Kiểm tra tên đội bóng
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                Logger.Instance.Log("Tên đội bóng không được để trống.", LogLevel.Warning);
                MyMessageBox.ShowError("Tên đội bóng không được để trống.");
                txtTeamName.Focus();
                return false;
            }

            // Kiểm tra huấn luyện viên
            if (string.IsNullOrWhiteSpace(txtCoachName.Text))
            {
                Logger.Instance.Log("Tên huấn luyện viên không được để trống.", LogLevel.Warning);
                MyMessageBox.ShowError("Tên huấn luyện viên không được để trống.");
                txtCoachName.Focus();
                return false;
            }

            // Kiểm tra email hợp lệ
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains('@'))
            {
                Logger.Instance.Log("Email không hợp lệ: {Email}", LogLevel.Warning);
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
                Logger.Instance.Log($"Thông tin đội bóng không hợp lệ: {error}", LogLevel.Error);
                MyMessageBox.ShowError(error);
                txtTeamName.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Logger.Instance.Log("Người dùng đã hủy bỏ và đóng form mà không thay đổi dữ liệu.");
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
            using (var frm = new FrmStadium())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string newStadiumId = frm.Tag as string;

                    if (!string.IsNullOrEmpty(newStadiumId))
                    {
                        // Ví dụ: gán vào ComboBox hoặc xử lý khác
                        cbHomeStadium.Items.Add(newStadiumId);
                        cbHomeStadium.SelectedItem = newStadiumId;
                    }
                }
            }
        }

    }
}
