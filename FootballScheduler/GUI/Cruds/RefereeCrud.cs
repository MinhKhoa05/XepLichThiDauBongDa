using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Forms;
using GUI.Helpers;

namespace GUI.Cruds
{
    public class RefereeCrud : ICrud
    {
        private readonly RefereeBUS _refereeBUS;
        private readonly DataGridView _dataGridView;

        public RefereeCrud(DataGridView dgv)
        {
            _refereeBUS = new RefereeBUS();
            _dataGridView = dgv;
        }

        // Thêm trọng tài
        public void Insert()
        {
            var form = new FrmRefereeInfo();
            var newReferee = CrudUIHelper.ShowEntityForm<RefereeDTO>(form);
            if (newReferee != null)
            {
                _refereeBUS.Insert(newReferee);
                LoadData();
            }
        }

        // Cập nhật trọng tài
        public void Update()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "RefereeID");
            if (id == null) return;

            var currentReferee = _refereeBUS.GetById(id);
            var updatedReferee = CrudUIHelper.ShowEntityForm<RefereeDTO>(new FrmRefereeInfo(currentReferee));
            if (updatedReferee != null)
            {
                _refereeBUS.Update(updatedReferee);
                LoadData();
            }
        }

        // Xóa trọng tài
        public void Delete()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "RefereeID");
            if (id == null) return;

            _refereeBUS.Delete(id);
            LoadData();
        }

        // Tải lại danh sách trọng tài vào DataGridView
        public void LoadData()
        {
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = _refereeBUS.GetAll();
        }

        // Xuất danh sách trọng tài ra PDF
        public void Export()
        {
            var referees = _refereeBUS.GetAll();
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
    }
}
