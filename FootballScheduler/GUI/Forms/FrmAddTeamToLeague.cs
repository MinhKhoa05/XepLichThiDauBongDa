using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using BUS.BUSs;
using GUI.Helpers;

namespace GUI.UserControls
{
    public partial class FrmAddTeamToLeague : Form
    {
        private readonly LeagueTeamBUS leagueTeamBUS = new LeagueTeamBUS();
        private readonly string _leagueID;
        private int maxTeams;  // Biến để lưu trữ giới hạn số đội cho giải đấu

        public FrmAddTeamToLeague(string leagueID)
        {
            InitializeComponent();
            _leagueID = leagueID;
        }

        private void FormAddTeamToLeague_Load(object sender, EventArgs e)
        {
            dgvTeams.AutoGenerateColumns = false;
            dgvTeams.DataSource = (new TeamBUS()).GetAll();
            LoadTeamJoin();

            // Lấy thông tin về giải đấu để xác định giới hạn số đội
            var league = (new LeagueBUS()).GetById(_leagueID);
            maxTeams = league?.MaxTeams ?? 0;  // Nếu không có giải đấu thì maxTeams là 0
        }

        private void LoadTeamJoin()
        {
            List<string> teamIDs = leagueTeamBUS.GetTeamsByLeagueID(_leagueID);

            foreach (DataGridViewRow row in dgvTeams.Rows)
            {
                if (row.IsNewRow) continue;

                string teamID = row.Cells["TeamID"].Value?.ToString();
                row.Cells["isJoin"].Value = teamID != null && teamIDs.Contains(teamID);
            }
        }

        private void SaveSelectedTeams()
        {
            List<string> selectedTeamIDs = new List<string>();

            foreach (DataGridViewRow row in dgvTeams.Rows)
            {
                if (row.IsNewRow) continue;

                bool isJoin = Convert.ToBoolean(row.Cells["isJoin"].Value);
                if (isJoin)
                {
                    selectedTeamIDs.Add(row.Cells["TeamID"].Value.ToString());
                }
            }

            leagueTeamBUS.AddTeamToLeague(_leagueID, selectedTeamIDs);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Kiểm tra số lượng đội được chọn
            int selectedTeamCount = dgvTeams.Rows.Cast<DataGridViewRow>()
                                               .Count(row => Convert.ToBoolean(row.Cells["isJoin"].Value));

            if (selectedTeamCount > maxTeams)
            {
                MyMessageBox.ShowWarning($"Số lượng đội tham gia không thể vượt quá {maxTeams} đội!");
                return;
            }

            SaveSelectedTeams();
            Close();
        }

        private void dgvTeams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && dgvTeams.Columns[e.ColumnIndex].Name == "isJoin")
            {
                bool allSelected = dgvTeams.Rows.Cast<DataGridViewRow>()
                                      .All(row => Convert.ToBoolean(row.Cells["isJoin"].Value) == true);

                foreach (DataGridViewRow row in dgvTeams.Rows)
                {
                    row.Cells["isJoin"].Value = !allSelected;
                }
            }
        }

        private void dgvTeams_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && dgvTeams.Columns[e.ColumnIndex].Name == "isJoin")
            {
                dgvTeams.Columns["isJoin"].HeaderCell.ToolTipText = "Nhấn đúp để chọn/bỏ chọn tất cả!";
            }
        }

        private void dgvTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                bool currentValue = Convert.ToBoolean(dgvTeams.Rows[e.RowIndex].Cells["isJoin"].Value);
                dgvTeams.Rows[e.RowIndex].Cells["isJoin"].Value = !currentValue;
            }
        }
    }
}
