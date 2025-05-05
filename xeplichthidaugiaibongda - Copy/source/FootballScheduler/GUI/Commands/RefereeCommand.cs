using System.Collections.Generic;
using System;
using System.Windows.Forms;
using BUS.Services;
using DTO;
using GUI.Forms;
using GUI.Helpers;

namespace GUI.Commands
{
    public class RefereeCommand : CurdCommandBase<RefereeDTO>
    {
        private readonly RefereeBUS _refereeBUS = new RefereeBUS();

        // Constructor nhận vào DataGridView
        public RefereeCommand(DataGridView dgv)
            : base(dgv) { }

        #region CRUD Actions

        /// <summary>
        /// Lấy đối tượng RefereeDTO theo ID.
        /// </summary>
        protected override RefereeDTO GetEntityById(string id)
        {
            return _refereeBUS.GetById(id);
        }

        /// <summary>
        /// Thực hiện thao tác thêm mới Referee.
        /// </summary>
        protected override void ExecuteInsert(RefereeDTO entity)
        {
            _refereeBUS.Insert(entity);
        }

        /// <summary>
        /// Thực hiện thao tác cập nhật Referee.
        /// </summary>
        protected override void ExecuteUpdate(RefereeDTO entity)
        {
            _refereeBUS.Update(entity);
        }

        protected override void ExecuteDelete(RefereeDTO entity)
        {
            _refereeBUS.Delete(entity.RefereeID);
        }

        /// <summary>
        /// Thực hiện thao tác xóa mềm Referee (đánh dấu đã xóa).
        /// </summary>
        protected override void ExecuteSoftDelete(RefereeDTO entity)
        {
            _refereeBUS.SoftDelete(entity.RefereeID);
        }

        /// <summary>
        /// Thực hiện khôi phục Referee đã xóa mềm.
        /// </summary>
        protected override void ExecuteRestore(RefereeDTO entity)
        {
            _refereeBUS.Restore(entity.RefereeID);
        }

        /// <summary>
        /// Tạo form chỉnh sửa thông tin Referee.
        /// </summary>
        protected override Form CreateForm(RefereeDTO entity = null)
        {
            return new FrmRefereeInfo(entity);
        }

        #endregion

        #region Tải và xuất dữ liệu

        /// <summary>
        /// Tải lại danh sách Referee vào DataGridView.
        /// </summary>
        public override void Load()
        {
            _dataGridView.DataSource = null;  // Xóa dữ liệu cũ
            _dataGridView.DataSource = _refereeBUS.GetAll();  // Lấy lại dữ liệu mới
        }

        /// <summary>
        /// Xuất dữ liệu (chưa được hiện thực).
        /// </summary>
        public override void Export()
        {
            var referees = _refereeBUS.GetAll();  // Lấy danh sách trọng tài từ cơ sở dữ liệu

            // Cung cấp tiêu đề và các thông tin cột cần xuất ra PDF
            PdfExportHelper.ExportToPdf(
                referees, // Dữ liệu cần xuất ra
                "DANH SÁCH TRỌNG TÀI", // Tiêu đề
                new List<string> { "Mã Trọng Tài", "Tên Trọng Tài", "Ngày Sinh", "Số Điện Thoại", "Email" }, // Các tiêu đề cột
                new List<Func<RefereeDTO, string>> // Các extractor để lấy dữ liệu từ đối tượng RefereeDTO
                {
                    referee => referee.RefereeID,
                    referee => referee.RefereeName,
                    referee => referee.BirthDate.ToString("dd/MM/yyyy"),
                    referee => referee.PhoneNumber,
                    referee => referee.Email
                });
        }

        #endregion
    }
}
