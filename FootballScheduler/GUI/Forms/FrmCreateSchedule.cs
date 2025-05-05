using System;
using System.Windows.Forms;
using BUS.Managers;
using BUS.Services;
using GUI.Helpers;
using GUI.UserControls;

namespace GUI.Forms
{
    public partial class FrmCreateSchedule : Form
    {
        private MatchManager _matchManager;
        private readonly LeagueBUS _leagueBUS = new LeagueBUS();
        private string _leagueID;  // Thêm thuộc tính LeagueID

        public FrmCreateSchedule(string leagueID)  // Chỉ nhận LeagueID
        {
            InitializeComponent();
            dgvTeams.AutoGenerateColumns = false;
            _leagueID = leagueID;  // Lưu LeagueID vào biến lớp
            _matchManager = new MatchManager();
        }

        private void FormCreateSchedule_Load(object sender, EventArgs e)
        {
            InitializeMatchManager();
            ConfigureDataGridView();
        }

        private void InitializeMatchManager()
        {
            // Sử dụng LeagueID đã được truyền vào
            _matchManager.LeagueID = _leagueID;
            txtLeagueName.Text = _leagueBUS.GetById(_leagueID).LeagueName;
        }

        private void ConfigureDataGridView()
        {
            dgvTeams.AutoGenerateColumns = false;
            dgvTeams.DataSource = _matchManager.Teams;
        }

        private void btnDieuChinh_Click(object sender, EventArgs e)
        {
            OpenAddTeamForm();
        }

        private void OpenAddTeamForm()
        {
            using (var form = new FrmAddTeamToLeague(_matchManager.LeagueID))
            {
                form.ShowDialog();
            }

            _matchManager.UpdateTeams();
            UpdateTeamsDataGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _matchManager.GenerateSchedule();
            _matchManager.SaveSchedule();
            MyMessageBox.ShowInformation("Lịch thi đấu đã được tạo và lưu vào hệ thống!");
            this.Close();
        }

        private void dgvTeams_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateRowIndex();
        }

        private void UpdateRowIndex()
        {
            for (int i = 0; i < dgvTeams.Rows.Count; i++)
            {
                dgvTeams.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void UpdateTeamsDataGrid()
        {
            // Nếu dữ liệu đã thay đổi, cần gọi lại ResetBindings hoặc gán lại DataSource
            dgvTeams.DataSource = null;  // Đặt DataSource về null trước khi gán lại
            dgvTeams.DataSource = _matchManager.Teams;
            dgvTeams.Refresh();  // Đảm bảo DataGridView được vẽ lại với dữ liệu mới
        }
    }
}
