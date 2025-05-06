using System;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmMatchInfo : Form
    {
        private readonly MatchDTO _originalMatch;
        private readonly bool _isUpdateSchedule;

        private readonly TeamBUS teamBUS = new TeamBUS();
        private readonly StadiumBUS stadiumBUS = new StadiumBUS();
        private readonly RefereeBUS refereeBUS = new RefereeBUS();

        public FrmMatchInfo(MatchDTO match = null, bool isUpdateSchedule = true)
        {
            InitializeComponent();
            _originalMatch = match;
            _isUpdateSchedule = isUpdateSchedule;
        }

        private void FrmMatchInfo_Load(object sender, EventArgs e)
        {
            LoadComboBoxStadium();

            // Load referees into the combo box
            LoadComboBoxReferee();

            if (_originalMatch != null)
            {
                DisplayMatchInfo(_originalMatch);
            }
            else
            {
                // Default values if there is no match
                dtpMatchDate.Value = DateTime.Today;
                numUDHours.Value = 18;
                numUDMinutes.Value = 0;
                numUDHomeGoals.Value = 0;
                numUDAwayGoals.Value = 0;
            }

            // Chế độ: cập nhật lịch hoặc kết quả
            if (_isUpdateSchedule)
            {
                panelLich.Enabled = true;
                panelResult.Enabled = false;

                cbReferee.Enabled = true; // Enable referee selection
                cbStadium.Enabled = true; // Enable stadium selection
            }
            else
            {
                panelLich.Enabled = false;
                panelResult.Enabled = true;

                cbReferee.Enabled = false; // Disable referee selection
                cbStadium.Enabled = false; // Disable stadium selection
            }
        }

        private void DisplayMatchInfo(MatchDTO match)
        {
            var homeTeam = teamBUS.GetById(match.HomeTeamID);
            var awayTeam = teamBUS.GetById(match.AwayTeamID);

            lblHomeTeam.Text = homeTeam?.TeamName ?? "Chưa xác định";
            lblAwayTeam.Text = awayTeam?.TeamName ?? "Chưa xác định";

            picBoxHomeTeamLogo.Image = ImageHelper.GetImageFromFile(homeTeam?.LogoURL, 225, 216);
            picBoxAwayTeamLogo.Image = ImageHelper.GetImageFromFile(awayTeam?.LogoURL, 225, 216);

            dtpMatchDate.Value = match.KickoffDateTime.Date;
            numUDHours.Value = match.KickoffDateTime.Hour;
            numUDMinutes.Value = match.KickoffDateTime.Minute;

            numUDHomeGoals.Value = match.HomeGoals;
            numUDAwayGoals.Value = match.AwayGoals;

            cbStadium.SelectedValue = match.StadiumID;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            MatchDTO result = CreateMatchDTO();
            this.Tag = result;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (_isUpdateSchedule)
            {
                if (cbStadium.SelectedValue == null)
                {
                    MyMessageBox.ShowError("Vui lòng chọn sân vận động.");
                    return false;
                }

                if (cbReferee.SelectedValue == null)
                {
                    MyMessageBox.ShowError("Vui lòng chọn trọng tài.");
                    return false;
                }
            }

            return true;
        }

        private MatchDTO CreateMatchDTO()
        {
            var matchTime = dtpMatchDate.Value.Date
                .AddHours((double)numUDHours.Value)
                .AddMinutes((double)numUDMinutes.Value);

            return new MatchDTO
            {
                MatchID = _originalMatch.MatchID,
                HomeTeamID = _originalMatch?.HomeTeamID,
                AwayTeamID = _originalMatch?.AwayTeamID,
                KickoffDateTime = _isUpdateSchedule ? matchTime : _originalMatch.KickoffDateTime,
                HomeGoals = _isUpdateSchedule ? _originalMatch.HomeGoals : Convert.ToByte(numUDHomeGoals.Value),
                AwayGoals = _isUpdateSchedule ? _originalMatch.AwayGoals : Convert.ToByte(numUDAwayGoals.Value),
                StadiumID = _isUpdateSchedule ? cbStadium.SelectedValue.ToString() : _originalMatch.StadiumID,
                RefereeID = _isUpdateSchedule ? cbReferee.SelectedValue.ToString() : _originalMatch.RefereeID,
                Complete = !_isUpdateSchedule ? true : _originalMatch.Complete,
            };
        }

        private void LoadComboBoxStadium()
        {
            cbStadium.DataSource = stadiumBUS.GetAll();
            cbStadium.DisplayMember = "StadiumName";
            cbStadium.ValueMember = "StadiumID";
            cbStadium.SelectedValue = _originalMatch?.StadiumID;
        }

        private void LoadComboBoxReferee()
        {
            cbReferee.DataSource = refereeBUS.GetAll();
            cbReferee.DisplayMember = "RefereeName";
            cbReferee.ValueMember = "RefereeID";
            cbReferee.SelectedValue = _originalMatch?.RefereeID;
        }
    }
}
