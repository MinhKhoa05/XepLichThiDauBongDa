using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;

namespace GUI.UserControls
{
    public partial class UcStandings : UserControl
    {
        private readonly StandingsBUS _standingsBUS = new StandingsBUS();

        public UcStandings()
        {
            InitializeComponent();
        }

        private void UcStandings_Load(object sender, EventArgs e)
        {
            // Lấy danh sách các giải đấu và gán vào ComboBox
            var leagues = new LeagueBUS().GetAll();
            cbLeague.DataSource = leagues;
            cbLeague.DisplayMember = "LeagueName";
            cbLeague.ValueMember = "LeagueID";

            // Tải dữ liệu bảng xếp hạng nếu có giải đấu được chọn
            if (cbLeague.SelectedValue != null)
            {
                LoadStandingsData(cbLeague.SelectedValue.ToString());
            }
        }

        private void cbLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tải lại dữ liệu bảng xếp hạng khi giải đấu được chọn thay đổi
            var selectedLeagueId = cbLeague.SelectedValue as string;
            if (!string.IsNullOrEmpty(selectedLeagueId))
            {
                LoadStandingsData(selectedLeagueId);
            }
        }

        private void LoadStandingsData(string leagueId)
        {
            // Làm sạch DataGridView trước khi gán lại dữ liệu
            dgvStandings.DataSource = null;
            dgvStandings.AutoGenerateColumns = false;

            // Lấy dữ liệu bảng xếp hạng và gán vào DataGridView
            var standings = _standingsBUS.GetAll(leagueId);
            dgvStandings.DataSource = standings;
        }

        private void dgvStandings_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Cập nhật số thứ tự cho từng dòng trong DataGridView
            for (int i = 0; i < dgvStandings.Rows.Count; i++)
            {
                dgvStandings.Rows[i].Cells["Rank"].Value = i + 1;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var leagueId = cbLeague.SelectedValue as string;
            var leagueName = cbLeague.Text;

            // Kiểm tra xem có dữ liệu bảng xếp hạng
            var standings = _standingsBUS.GetAll(leagueId);
            if (standings == null || standings.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Khai báo headers và extractors cho dữ liệu bảng xếp hạng
            var headers = new List<string>
            {
                "Đội", "Trận", "Thắng", "Hòa", "Thua", "Bàn thắng/Bàn thua", "Hiệu số", "Điểm"
            };

            var extractors = new List<Func<StandingsDTO, string>>
            {
                s => s.TeamName,
                s => s.MatchesPlayed.ToString(),
                s => s.Wins.ToString(),
                s => s.Draws.ToString(),
                s => s.Losses.ToString(),
                s => string.Format("{0}/{1}", s.GoalsScored, s.GoalsConceded),
                s => s.GoalDiff.ToString(),
                s => s.Points.ToString()
            };

            // Xuất dữ liệu ra PDF
            PdfExportHelper.ExportToPdf(standings, $"BẢNG XẾP HẠNG GIẢI {leagueName}", headers, extractors);
        }
    }
}
