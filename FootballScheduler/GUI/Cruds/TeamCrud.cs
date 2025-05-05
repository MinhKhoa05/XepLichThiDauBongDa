using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.Services;
using DTO;
using GUI.Cruds;
using GUI.Forms;
using GUI.Helpers;

namespace GUI.Curds
{
    public class TeamCrud : ICrud
    {
        private readonly TeamBUS _teamBUS;
        private readonly DataGridView _dataGridView;
        
        public TeamCrud(DataGridView dgv)
        {
            _teamBUS = new TeamBUS();
            _dataGridView = dgv;
        }

        // Thêm đội bóng
        public void Insert()
        {
            var form = new FrmTeamInfo();
            var newTeam = CrudUIHelper.ShowEntityForm<TeamDTO>(form);
            if (newTeam != null)
            {
                _teamBUS.Insert(newTeam);
                LoadData();
            }
        }

        // Cập nhật đội bóng
        public void Update()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "TeamID");
            if (id == null) return;

            var currentTeam = _teamBUS.GetById(id);
            var updatedTeam = CrudUIHelper.ShowEntityForm<TeamDTO>(new FrmTeamInfo(currentTeam));
            if (updatedTeam != null)
            {
                _teamBUS.Update(updatedTeam);
                LoadData();
            }
        }

        // Xóa đội bóng
        public void Delete()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "TeamID");
            if (id == null) return;

            _teamBUS.Delete(id);
            LoadData();
        }

        // Tải lại danh sách đội bóng vào DataGridView
        public void LoadData()
        {
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = _teamBUS.GetAll();
        }

        // Xuất danh sách đội bóng ra PDF
        public void Export()
        {
            var teams = _teamBUS.GetAll();
            PdfExportHelper.ExportToPdf(
                teams, // Dữ liệu cần xuất ra
                "DANH SÁCH ĐỘI BÓNG", // Tiêu đề
                new List<string> { "Mã Đội Bóng", "Tên Đội Bóng", "Đại diện", "Số Điện Thoại", "Email" }, // Các tiêu đề cột
                new List<Func<TeamDTO, string>> // Các extractor để lấy dữ liệu từ đối tượng TeamDTO
                {
                    team => team.TeamID,
                    team => team.TeamName,
                    team => team.CoachName,
                    team => team.Phone,
                    team => team.Email
                });
        }
    }
}
