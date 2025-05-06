using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool isRefereeMode = false;
        private readonly MatchBUS _matchBUS = new MatchBUS();

        public UcSchedule()
        {
            InitializeComponent();
            cbLeague.SelectedIndexChanged += cbLeague_SelectedIndexChanged;
        }

        private void UcSchedule_Load(object sender, EventArgs e)
        {
            if (FrmMain.Account.Role.Equals("Referee"))
            {
                isRefereeMode = true;
                var referees = new List<RefereeDTO>
                {
                    new RefereeBUS().GetById(FrmMain.Account.AccountID),
                    new RefereeDTO
                    {
                        RefereeID = "ALL",
                        RefereeName = "== Tất cả =="
                    }
                };

                cbLeague.DataSource = referees;
                cbLeague.DisplayMember = "RefereeName";
                cbLeague.ValueMember = "RefereeID";

                btnUpdateResult.Enabled = true;
            }
            else
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
            }

            if (cbLeague.SelectedValue != null)
            {
                leagueId = cbLeague.SelectedValue.ToString();
                LoadMatchData();
            }

            PhanQuyen();
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

            List<MatchView> matches;

            if (isRefereeMode)
            {
                string refereeId = cbLeague.SelectedValue?.ToString();
                matches = refereeId == "ALL"
                    ? _matchBUS.GetAll()
                    : _matchBUS.Filter(refereeId); // Filter theo RefereeID
            }
            else
            {
                matches = leagueId == "ALL"
                    ? _matchBUS.GetAll()
                    : _matchBUS.GetAll(leagueId);
            }

            dgvMatch.DataSource = matches;
            dgvMatch.Columns["LeagueName"].Visible = !isRefereeMode && leagueId == "ALL";
            dgvMatch.BindingContext[dgvMatch.DataSource].SuspendBinding();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (leagueId == "ALL" && !isRefereeMode)
            {
                MessageBox.Show("Vui lòng chọn giải đấu để xuất dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var matches = isRefereeMode
                ? _matchBUS.Filter(leagueId)
                : _matchBUS.GetAll(leagueId);

            string title = isRefereeMode
                ? "LỊCH THI ĐẤU CỦA TRỌNG TÀI"
                : $"LỊCH THI ĐẤU GIẢI {new LeagueBUS().GetById(leagueId).LeagueName}";

            PdfExportHelper.ExportToPdf(
                matches,
                title,
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenMatchEditor(true);
        }

        private void btnUpdateResult_Click(object sender, EventArgs e)
        {
            OpenMatchEditor(false);
        }

        private void OpenMatchEditor(bool isUpdateSchedule)
        {
            string matchId = dgvMatch.CurrentRow?.Cells["MatchID"].Value?.ToString();

            if (string.IsNullOrEmpty(matchId))
            {
                string action = isUpdateSchedule ? "cập nhật lịch thi đấu" : "cập nhật kết quả";
                MyMessageBox.ShowError($"Vui lòng chọn trận đấu để {action}.");
                return;
            }

            var match = _matchBUS.GetById(matchId);

            using (var form = new FrmMatchInfo(match, isUpdateSchedule))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    var updatedMatch = form.Tag as MatchDTO;
                    try
                    {
                        _matchBUS.Update(updatedMatch);
                        string successAction = isUpdateSchedule ? "Cập nhật lịch thi đấu" : "Cập nhật kết quả";
                        MyMessageBox.ShowInformation($"{successAction} thành công!");
                    }
                    catch (Exception ex)
                    {
                        string errorAction = isUpdateSchedule ? "Thay đổi lịch thi đấu" : "Cập nhật kết quả";
                        MyMessageBox.ShowError($"{errorAction} thất bại: {ex.Message}");
                        return;
                    }

                    LoadMatchData();
                }
            }
        }

        private void PhanQuyen()
        {
            if (!FrmMain.Account.Role.Equals("Admin"))
            {
                btnEdit.Enabled = false;
                btnUpdateResult.Enabled = false;
                btnInsert.Enabled = false;
            }

            if (FrmMain.Account.Role.Equals("Referee"))
            {
                btnUpdateResult.Enabled = true;
            }
        }
    }
}
