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
                MyMessageBox.ShowInformation("Thêm trọng tài thành công!");
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
                MyMessageBox.ShowInformation("Cập nhật trọng tài thành công!");
            }
        }

        // Xóa trọng tài
        public void Delete()
        {
            var id = CrudUIHelper.GetSelectedId(_dataGridView, "RefereeID");
            if (id == null) return;

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa trọng tài này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _refereeBUS.Delete(id);
                LoadData();
                MyMessageBox.ShowInformation("Xóa trọng tài thành công!");
            }
            catch
            {
                MyMessageBox.ShowError("Không thể xóa trọng tài!");
            }
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
                referees,
                "DANH SÁCH TRỌNG TÀI",
                new List<string> { "Mã Trọng Tài", "Tên Trọng Tài", "Ngày Sinh", "Số Điện Thoại", "Email" },
                new List<Func<RefereeDTO, string>>
                {
                    referee => referee.RefereeID,
                    referee => referee.RefereeName,
                    referee => referee.BirthDate.ToString("dd/MM/yyyy"),
                    referee => referee.PhoneNumber,
                    referee => referee.Email
                });

            MyMessageBox.ShowInformation("Xuất danh sách trọng tài thành công!");
        }

        // Tìm kiếm trọng tài theo từ khóa
        public void Search(string keyword)
        {
            var referees = _refereeBUS.Search(keyword);
            _dataGridView.DataSource = null;
            _dataGridView.DataSource = referees;
        }
    }
}
