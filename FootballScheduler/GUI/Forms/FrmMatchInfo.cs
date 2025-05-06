using System;
using System.Linq;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmMatchInfo : Form
    {
        private readonly MatchDTO _originalMatch;

        private readonly TeamBUS teamBUS = new TeamBUS();
        private readonly StadiumBUS stadiumBUS = new StadiumBUS();
        private readonly RefereeBUS refereeBUS = new RefereeBUS();

        public FrmMatchInfo(MatchDTO match = null)
        {
            InitializeComponent();
            _originalMatch = match;
        }

        private void FrmMatchInfo_Load(object sender, EventArgs e)
        {
            LoadComboBoxStadium();

            if (_originalMatch != null)
            {
                DisplayMatchInfo(_originalMatch);
                LoadAvailableReferees(_originalMatch.KickoffDateTime);
            }
            else
            {
                dtpMatchDate.Value = DateTime.Today;
                numUDHours.Value = 18;
                numUDMinutes.Value = 0;
                numUDHomeGoals.Value = 0;
                numUDAwayGoals.Value = 0;
                LoadAvailableReferees(DateTime.Today.AddHours(18));
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
                KickoffDateTime = matchTime,
                HomeGoals = Convert.ToByte(numUDHomeGoals.Value),
                AwayGoals = Convert.ToByte(numUDAwayGoals.Value),
                StadiumID = cbStadium.SelectedValue.ToString(),
                RefereeID = cbReferee.SelectedValue.ToString(),
            };
        }

        private void LoadComboBoxStadium()
        {
            cbStadium.DataSource = stadiumBUS.GetAll();
            cbStadium.DisplayMember = "StadiumName";
            cbStadium.ValueMember = "StadiumID";
        }

        private void LoadAvailableReferees(DateTime dateTime)
        {
            var referees = refereeBUS.GetAvailableReferees(dateTime);

            if (_originalMatch != null && !referees.Any(r => r.RefereeID == _originalMatch.RefereeID))
            {
                var current = refereeBUS.GetById(_originalMatch.RefereeID);
                if (current != null) referees.Insert(0, current);
            }

            cbReferee.DataSource = referees;
            cbReferee.DisplayMember = "RefereeName";
            cbReferee.ValueMember = "RefereeID";
        }
    }
}
