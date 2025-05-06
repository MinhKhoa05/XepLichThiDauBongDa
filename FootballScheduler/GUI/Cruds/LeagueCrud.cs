using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Forms;
using GUI.Helpers;

namespace GUI.Cruds
{
    public class LeagueCrud : ICrud
    {
        private readonly LeagueBUS _leagueBUS;
        private readonly DataGridView _dataGridView;

        public LeagueCrud(DataGridView dgv)
        {
            _leagueBUS = new LeagueBUS();
            _dataGridView = dgv;
        }

        // Thêm giải đấu
        public void Insert()
        {
            var form = new FrmLeagueInfo();
            var newLeague = CrudUIHelper.ShowEntityForm<LeagueDTO>(form);
            if (newLeague != null)
            {
                _leagueBUS.Insert(newLeague);
                LoadData();
                MyMessageBox.ShowInformation("Thêm giải đấu thành công!");
            }
        }

        // Cập nhật giải đấu
        public void Update()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "LeagueID");
            if (id == null) return;

            var currentLeague = _leagueBUS.GetById(id);
            var updatedLeague = CrudUIHelper.ShowEntityForm<LeagueDTO>(new FrmLeagueInfo(currentLeague));
            if (updatedLeague != null)
            {
                _leagueBUS.Update(updatedLeague);
                LoadData();
                MyMessageBox.ShowInformation("Cập nhật giải đấu thành công!");
            }
        }

        // Xóa giải đấu
        public void Delete()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "LeagueID");
            if (id == null) return;

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa giải đấu này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                _leagueBUS.Delete(id);
                LoadData();
                MyMessageBox.ShowInformation("Xóa giải đấu thành công!");
            }
        }

        // Tải lại danh sách lên DataGridView
        public void LoadData()
        {
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = _leagueBUS.GetAll();
        }

        // Xuất PDF danh sách
        public void Export()
        {
            var leagues = _leagueBUS.GetAll();
            PdfExportHelper.ExportToPdf(
                leagues,
                "DANH SÁCH GIẢI ĐẤU",
                new List<string> { "Mã Giải Đấu", "Tên Giải Đấu", "Ngày Bắt Đầu", "Ngày Kết Thúc", "Số đội tối đa" },
                new List<Func<LeagueDTO, string>>
                {
                    league => league.LeagueID,
                    league => league.LeagueName,
                    league => league.StartDate.ToString("dd/MM/yyyy"),
                    league => league.EndDate.ToString("dd/MM/yyyy"),
                    league => league.MaxTeams.ToString()
                });

            MyMessageBox.ShowInformation("Xuất danh sách giải đấu thành công!");
        }

        // Tìm kiếm giải đấu
        public void Search(string searchTerm)
        {
            var leagues = _leagueBUS.Search(searchTerm);
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = leagues;
        }
    }
}
