using System;
using System.Windows.Forms;
using BUS.Managers;
using BUS.BUSs;
using GUI.Helpers;
using GUI.UserControls;

namespace GUI.Forms
{
    public partial class FrmCreateSchedule : Form
    {
        private MatchManager _matchManager;
        private readonly LeagueBUS _leagueBUS = new LeagueBUS();
        private readonly string _leagueID;

        public FrmCreateSchedule(string leagueID)
        {
            InitializeComponent();
            dgvTeams.AutoGenerateColumns = false;
            _leagueID = leagueID;
            _matchManager = new MatchManager();
        }

        private void FormCreateSchedule_Load(object sender, EventArgs e)
        {
            _matchManager.LeagueID = _leagueID;
            txtLeagueName.Text = _leagueBUS.GetById(_leagueID).LeagueName;

            dgvTeams.DataSource = _matchManager.Teams;
        }

        private void btnDieuChinh_Click(object sender, EventArgs e)
        {
            using (var form = new FrmAddTeamToLeague(_matchManager.LeagueID))
            {
                form.ShowDialog();
            }

            _matchManager.UpdateTeams();

            dgvTeams.DataSource = null;
            dgvTeams.DataSource = _matchManager.Teams;
            dgvTeams.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy và kiểm tra input giờ từ MaskedTextBox (ví dụ: "08:30")
            string inputTime = maskedStartTime.Text.Trim();
            if (string.IsNullOrEmpty(inputTime))
            {
                errorProvider1.SetError(maskedStartTime, "Vui lòng nhập giờ bắt đầu.");
                maskedStartTime.Focus();
                return;
            }

            if (!TimeSpan.TryParse(inputTime, out TimeSpan startTime))
            {
                errorProvider1.SetError(maskedStartTime, "Giờ không hợp lệ (định dạng HH:mm).");
                maskedStartTime.Focus();
                return;
            }

            // Giờ hợp lệ nằm trong khoảng 08:00 - 20:00
            TimeSpan allowedStart = new TimeSpan(8, 0, 0);   // 08:00
            TimeSpan allowedEnd = new TimeSpan(20, 0, 0);    // 20:00

            if (startTime < allowedStart || startTime > allowedEnd)
            {
                errorProvider1.SetError(maskedStartTime, "Giờ bắt đầu phải từ 08:00 đến 20:00.");
                maskedStartTime.Focus();
                return;
            }

            int intervalDays = (int)nudInterval.Value;

            _matchManager.GenerateSchedule(intervalDays, startTime);
            _matchManager.SaveSchedule();

            MyMessageBox.ShowInformation("Lịch thi đấu đã được tạo và lưu vào hệ thống!");
            this.Close();
        }

        private void dgvTeams_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvTeams.Rows.Count; i++)
            {
                dgvTeams.Rows[i].Cells["STT"].Value = i + 1;
            }
        }
    }
}
