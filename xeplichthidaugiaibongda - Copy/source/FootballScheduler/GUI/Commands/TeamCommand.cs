using System.Collections.Generic;
using System;
using System.Windows.Forms;
using BUS.Services;
using DTO;
using GUI.Forms;
using GUI.Helpers;

namespace GUI.Commands
{
    public class TeamCommand : CurdCommandBase<TeamDTO>
    {
        private readonly TeamBUS _teamBUS = new TeamBUS();

        // Constructor nhận vào DataGridView
        public TeamCommand(DataGridView dgv)
            : base(dgv) { }

        #region CRUD Actions

        /// <summary>
        /// Lấy đối tượng TeamDTO theo ID.
        /// </summary>
        protected override TeamDTO GetEntityById(string id)
        {
            return _teamBUS.GetById(id);
        }

        /// <summary>
        /// Thực hiện thao tác thêm mới Team.
        /// </summary>
        protected override void ExecuteInsert(TeamDTO entity)
        {
            _teamBUS.Insert(entity);
        }

        /// <summary>
        /// Thực hiện thao tác cập nhật Team.
        /// </summary>
        protected override void ExecuteUpdate(TeamDTO entity)
        {
            _teamBUS.Update(entity);
        }

        protected override void ExecuteDelete(TeamDTO entity)
        {
            _teamBUS.Delete(entity.TeamID);
        }

        /// <summary>
        /// Thực hiện thao tác xóa mềm Team (đánh dấu đã xóa).
        /// </summary>
        protected override void ExecuteSoftDelete(TeamDTO entity)
        {
            _teamBUS.SoftDelete(entity.TeamID);
        }

        /// <summary>
        /// Thực hiện khôi phục Team đã xóa mềm.
        /// </summary>
        protected override void ExecuteRestore(TeamDTO entity)
        {
            _teamBUS.Restore(entity.TeamID);
        }

        /// <summary>
        /// Tạo form chỉnh sửa thông tin Team.
        /// </summary>
        protected override Form CreateForm(TeamDTO entity = null)
        {
            return new FrmTeamInfo(entity);  // Trả về form chỉnh sửa hoặc tạo mới cho Team
        }

        #endregion

        #region Tải và xuất dữ liệu

        /// <summary>
        /// Tải lại danh sách Team vào DataGridView.
        /// </summary>
        public override void Load()
        {
            _dataGridView.DataSource = null;  // Xóa dữ liệu cũ
            _dataGridView.DataSource = _teamBUS.GetAll();  // Lấy lại dữ liệu mới
        }

        /// <summary>
        /// Xuất dữ liệu (chưa được hiện thực).
        /// </summary>
        public override void Export()
        {
            var teams = _teamBUS.GetAll();  // Lấy danh sách đội bóng từ cơ sở dữ liệu

            // Cung cấp tiêu đề và các thông tin cột cần xuất ra PDF
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

        #endregion
    }
}
