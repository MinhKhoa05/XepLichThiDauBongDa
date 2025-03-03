using System;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_SinhVienDeTai
    {
        private readonly DAL_SinhVienDeTai _dalSinhVienDeTai = new DAL_SinhVienDeTai();

        // Thêm Kết quả thực tập mới
        public void AddSinhVienDeTai(string maSV, string maDT, string noiThucTap, int quangDuong, decimal ketQua)
        {
            DTO_SinhVienDeTai svdt = new DTO_SinhVienDeTai(maSV, maDT, noiThucTap, quangDuong, ketQua);
            _dalSinhVienDeTai.AddSinhVienDeTai(svdt);
        }

        // Cập nhật thông tin thực tập
        public void UpdateSinhVienDeTai(string maSV, string maDT, string noiThucTap, int quangDuong, decimal ketQua)
        {
            DTO_SinhVienDeTai svdt = new DTO_SinhVienDeTai(maSV, maDT, noiThucTap, quangDuong, ketQua);
            _dalSinhVienDeTai.UpdateSinhVienDeTai(svdt);
        }

        // Lấy danh sách kết quả thực tập
        public DataTable SelectSinhVienDeTai()
        {
            return _dalSinhVienDeTai.SelectSinhVienDeTai();
        }

        // Xóa Kết quả thực tập
        public void DeleteSinhVienDeTai(string maSV, string maDT)
        {
            _dalSinhVienDeTai.DeleteSinhVienDeTai(maSV, maDT);
        }

        // Lấy danh sách Nơi thực tập
        public DataTable SelectNoiThucTap()
        {
            return _dalSinhVienDeTai.SelectNoiThucTap();
        }
    }
}