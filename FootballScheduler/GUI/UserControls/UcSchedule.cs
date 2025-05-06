using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;
using GUI.Forms;

namespace GUI.UserControls
{
    public partial class UcSchedule : UserControl
    {
        private string leagueId;
        private readonly MatchBUS _matchBUS = new MatchBUS();

        public UcSchedule()
        {
            InitializeComponent();
            cbLeague.SelectedIndexChanged += cbLeague_SelectedIndexChanged;
        }

        private void UcSchedule_Load(object sender, EventArgs e)
        {
            var leagues = new LeagueBUS().GetAll();
            leagues.Add(new LeagueDTO
            {
                LeagueID = "ALL",
                LeagueName = "== Tất cả =="
            });

            cbLeague.DataSource = leagues;
            cbLeague.DisplayMember = "LeagueName";
            cbLeague.ValueMember = "LeagueID";

            if (cbLeague.SelectedValue != null)
            {
                leagueId = cbLeague.SelectedValue.ToString();
                LoadMatchData();
            }
        }

        private void cbLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLeague.SelectedValue != null)
            {
                leagueId = cbLeague.SelectedValue.ToString();
                LoadMatchData();
            }
        }

        private void LoadMatchData()
        {
            dgvMatch.DataSource = null;
            dgvMatch.AutoGenerateColumns = false;

            dgvMatch.DataSource = leagueId == "ALL"
                ? _matchBUS.GetAll()
                : _matchBUS.GetAll(leagueId);
            
            dgvMatch.Columns["LeagueName"].Visible = leagueId == "ALL";
            dgvMatch.BindingContext[dgvMatch.DataSource].SuspendBinding();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (leagueId == "ALL")
            {
                MessageBox.Show("Vui lòng chọn giải đấu để xuất dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var matches = _matchBUS.GetAll(leagueId);

            var leagueName = new LeagueBUS().GetById(leagueId).LeagueName;
            PdfExportHelper.ExportToPdf(
                matches,
                $"LỊCH THI ĐẤU GIẢI {leagueName}",
                new List<string> { "Ngày", "Giờ", "Đội Nhà", "Đội Khách", "Địa điểm", "Trọng tài", "Kết Quả" },
                new List<Func<MatchView, string>>
                {
                    match => match.KickoffDateTime.Date.ToString("dd/MM/yyyy"),
                    match => match.KickoffDateTime.TimeOfDay.ToString(@"hh\:mm"),
                    match => match.HomeTeam,
                    match => match.AwayTeam,
                    match => match.StadiumName,
                    match => match.RefereeName,
                    match => match.Result
                });
        }

        private void dgvMatch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvMatch.Rows.Count; i++)
            {
                dgvMatch.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (leagueId == "ALL")
            {
                MyMessageBox.ShowWarning("Vui lòng chọn một giải đấu cụ thể để tạo lịch.");
                return;
            }

            var matches = _matchBUS.GetAll(leagueId);

            if (matches.Count > 0)
            {
                var result = MessageBox.Show("Lịch thi đấu đã tồn tại. Bạn có muốn xóa và tạo lại không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Gọi hàm xóa lịch thi đấu theo giải
                    _matchBUS.DeleteByLeagueID(leagueId);
                }
                else
                {
                    return;
                }
            }

            using (var form = new FrmCreateSchedule(leagueId))
            {
                form.ShowDialog();
            }

            LoadMatchData();
        }

        private void btnUpdateResult_Click(object sender, EventArgs e)
        {
            string matchId = dgvMatch.CurrentRow?.Cells["MatchID"].Value.ToString();

            if (string.IsNullOrEmpty(matchId))
            {
                MyMessageBox.ShowError("Vui lòng chọn trận đấu để cập nhật kết quả.");
                return;
            }

            using (var form = new FrmMatchInfo(_matchBUS.GetById(matchId)))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    var updatedMatch = form.Tag as MatchDTO;
                    try
                    {
                        _matchBUS.Update(updatedMatch);
                    } catch (Exception ex)
                    {
                        MyMessageBox.ShowError($"Cập nhật kết quả thất bại: {ex.Message}");
                        return;
                    }

                    LoadMatchData();
                }
            }
        }
    }
}
