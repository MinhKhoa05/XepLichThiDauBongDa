using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.BUSs;
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
                MyMessageBox.ShowInformation("Thêm đội bóng thành công!");
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
                MyMessageBox.ShowInformation("Cập nhật đội bóng thành công!");
            }
        }

        // Xóa đội bóng
        public void Delete()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "TeamID");
            if (id == null) return;

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa đội bóng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _teamBUS.Delete(id);
                LoadData();
                MyMessageBox.ShowInformation("Xóa đội bóng thành công!");
            }
            catch
            {
                MyMessageBox.ShowError("Không thể xóa đội bóng!");
            }
        }

        // Tải lại danh sách đội bóng vào DataGridView
        public void LoadData()
        {
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = _teamBUS.GetAll();

            // Thiết lập các header cho các cột
            _dataGridView.Columns["TeamID"].HeaderText = "ID";
            _dataGridView.Columns["TeamName"].HeaderText = "Tên Đội Bóng";
            _dataGridView.Columns["CoachName"].HeaderText = "Đại diện";
            _dataGridView.Columns["StadiumName"].HeaderText = "Sân Nhà";
            _dataGridView.Columns["Phone"].HeaderText = "Số Điện Thoại";
            _dataGridView.Columns["Email"].HeaderText = "Email";

            _dataGridView.Columns["StadiumID"].Visible = false;
        }

        // Xuất danh sách đội bóng ra PDF
        public void Export()
        {
            var teams = _teamBUS.GetAll();
            PdfExportHelper.ExportToPdf(
                teams,
                "DANH SÁCH ĐỘI BÓNG",
                new List<string> { "Mã Đội Bóng", "Tên Đội Bóng", "Sân nhà", "Đại diện", "Số Điện Thoại", "Email" },
                new List<Func<TeamDTO, string>>
                {
                    team => team.TeamID,
                    team => team.TeamName,
                    team => team.StadiumName,
                    team => team.CoachName,
                    team => team.Phone,
                    team => team.Email
                });

            MyMessageBox.ShowInformation("Xuất danh sách đội bóng thành công!");
        }

        // Tìm kiếm đội bóng
        public void Search(string kw)
        {
            var teams = _teamBUS.Search(kw);
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = teams;
        }
    }
}
