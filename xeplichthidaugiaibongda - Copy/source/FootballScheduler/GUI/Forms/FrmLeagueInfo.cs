using System;
using System.Windows.Forms;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmLeagueInfo : Form
    {
        private readonly LeagueDTO _originalLeague;

        public FrmLeagueInfo(LeagueDTO league = null)
        {
            InitializeComponent();
            _originalLeague = league;
        }

        private void FrmLeagueInfo_Load(object sender, EventArgs e)
        {
            if (_originalLeague != null)
                DisplayLeagueInfo(_originalLeague);
            else
            {
                dtpStartDate.MinDate = DateTime.Today.AddDays(-1);
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today.AddDays(1);
                txtMaxTeams.Text = "2";  // Giá trị mặc định cho MaxTeams
            }
        }

        private void DisplayLeagueInfo(LeagueDTO league)
        {
            txtLeagueName.Text = league.LeagueName;
            txtMaxTeams.Text = league.MaxTeams.ToString();
            dtpStartDate.Value = league.StartDate;
            dtpEndDate.Value = league.EndDate;

            if (!string.IsNullOrEmpty(league.LogoURL))
            {
                picBoxLogo.Image = ImageHelper.GetImageFromFile(league.LogoURL, 284, 270);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var updatedLeague = CreateLeagueDTO();

            if (!ValidateLeague(updatedLeague))
                return;

            this.Tag = updatedLeague;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateForm()
        {
            // Kiểm tra MaxTeams
            if (!byte.TryParse(txtMaxTeams.Text, out byte maxTeams))
            {
                MyMessageBox.ShowError("Số đội không được để trống hoặc không hợp lệ.");
                txtMaxTeams.Focus();
                return false;
            }

            if (_originalLeague != null) return true;

            // Kiểm tra ngày bắt đầu và kết thúc
            if (dtpStartDate.Value.Date < DateTime.Today)
            {
                MyMessageBox.ShowError("Ngày bắt đầu không được trong quá khứ.");
                dtpStartDate.Focus();
                return false;
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MyMessageBox.ShowError("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.");
                dtpEndDate.Focus();
                return false;
            }

            return true;
        }

        private LeagueDTO CreateLeagueDTO()
        {
            return new LeagueDTO
            {
                LeagueID = _originalLeague?.LeagueID,
                LeagueName = txtLeagueName.Text.Trim(),
                MaxTeams = byte.Parse(txtMaxTeams.Text),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                LogoURL = ImageHelper.SaveImageToFile("LeagueLogo", txtLeagueName.Text, picBoxLogo.Image)
            };
        }

        private bool ValidateLeague(LeagueDTO updatedLeague)
        {
            if (!ValidatorHelper.TryValidate(updatedLeague, out var error))
            {
                MyMessageBox.ShowError(error);
                txtLeagueName.Focus();
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

        private void txtMaxTeams_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
