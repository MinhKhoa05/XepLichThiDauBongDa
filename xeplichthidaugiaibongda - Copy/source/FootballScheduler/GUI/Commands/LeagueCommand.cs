using System.Collections.Generic;
using System;
using System.Windows.Forms;
using BUS.Services;
using DTO;
using GUI.Forms;
using GUI.Helpers;

namespace GUI.Commands
{
    public class LeagueCommand : CurdCommandBase<LeagueDTO>
    {
        private readonly LeagueBUS _leagueBUS = new LeagueBUS();

        // Constructor nhận vào DataGridView
        public LeagueCommand(DataGridView dgv)
            : base(dgv) { }

        #region CRUD Actions

        /// <summary>
        /// Lấy đối tượng LeagueDTO theo ID.
        /// </summary>
        protected override LeagueDTO GetEntityById(string id)
        {
            return _leagueBUS.GetById(id);
        }

        /// <summary>
        /// Thực hiện thao tác thêm mới League.
        /// </summary>
        protected override void ExecuteInsert(LeagueDTO entity)
        {
            _leagueBUS.Insert(entity);
        }

        /// <summary>
        /// Thực hiện thao tác cập nhật League.
        /// </summary>
        protected override void ExecuteUpdate(LeagueDTO entity)
        {
            _leagueBUS.Update(entity);
        }

        protected override void ExecuteDelete(LeagueDTO entity)
        {
            _leagueBUS.Delete(entity.LeagueID);
        }

        /// <summary>
        /// Thực hiện thao tác xóa mềm League (đánh dấu đã xóa).
        /// </summary>
        protected override void ExecuteSoftDelete(LeagueDTO entity)
        {
            _leagueBUS.SoftDelete(entity.LeagueID);
        }

        /// <summary>
        /// Thực hiện khôi phục League đã xóa mềm.
        /// </summary>
        protected override void ExecuteRestore(LeagueDTO entity)
        {
            _leagueBUS.Restore(entity.LeagueID);
        }

        /// <summary>
        /// Tạo form chỉnh sửa thông tin League.
        /// </summary>
        protected override Form CreateForm(LeagueDTO entity = null)
        {
            return new FrmLeagueInfo(entity);
        }

        #endregion

        #region Tải và xuất dữ liệu

        /// <summary>
        /// Tải lại danh sách League vào DataGridView.
        /// </summary>
        public override void Load()
        {
            _dataGridView.DataSource = null;  // Xóa dữ liệu cũ
            _dataGridView.DataSource = _leagueBUS.GetAll();  // Lấy lại dữ liệu mới
        }

        /// <summary>
        /// Xuất dữ liệu (chưa được hiện thực).
        /// </summary>
        public override void Export()
        {
            var leagues = _leagueBUS.GetAll();  // Lấy danh sách giải đấu từ cơ sở dữ liệu

            // Cung cấp tiêu đề và các thông tin cột cần xuất ra PDF
            PdfExportHelper.ExportToPdf(
                leagues, // Dữ liệu cần xuất ra
                "DANH SÁCH GIẢI ĐẤU", // Tiêu đề
                new List<string> { "Mã Giải Đấu", "Tên Giải Đấu", "Ngày Bắt Đầu", "Ngày Kết Thúc" }, // Các tiêu đề cột
                new List<Func<LeagueDTO, string>> // Các extractor để lấy dữ liệu từ đối tượng LeagueDTO
                {
                    league => league.LeagueID,
                    league => league.LeagueName,
                    league => league.StartDate.ToString("dd/MM/yyyy"),
                    league => league.EndDate.ToString("dd/MM/yyyy")
                });
        }

        #endregion
    }
}