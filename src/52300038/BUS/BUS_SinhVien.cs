using System;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_SinhVien
    {
        private readonly DAL_SinhVien _dalSinhVien = new DAL_SinhVien();

        // Thêm Sinh viên mới
        public void AddSinhVien(string maSV, string hoTen, string queQuan, DateTime ngaySinh, decimal hocLuc)
        {
            DTO_SinhVien sv = new DTO_SinhVien(maSV, hoTen, queQuan, ngaySinh, hocLuc);
            _dalSinhVien.AddSinhVien(sv);
        }

        // Cập nhật thông tin Sinh viên
        public void UpdateSinhVien(string maSV, string hoTen, string queQuan, DateTime ngaySinh, decimal hocLuc)
        {
            DTO_SinhVien sv = new DTO_SinhVien(maSV, hoTen, queQuan, ngaySinh, hocLuc);
            _dalSinhVien.UpdateSinhVien(sv);
        }

        // Lấy danh sách Sinh viên
        public DataTable SelectSinhVien()
        {
            return _dalSinhVien.SelectSinhVien();
        }

        // Lấy Danh sách Mã và Tên Sinh viên
        public DataTable SelectMaVaTenSinhVien()
        {
            return _dalSinhVien.SelectMaVaTenSinhVien();
        }

        // Xóa Sinh viên theo Mã số
        public void DeleteSinhVien(string maSV)
        {
            _dalSinhVien.DeleteSinhVien(maSV);
        }

        // Lấy danh sách Quê quán
        public DataTable SelectQueQuan()
        {
            return _dalSinhVien.SelectQueQuan();
        }

        public DataTable GetSinhVienByQueQuan(string queQuan)
        {
            return _dalSinhVien.SelectSinhVienByQueQuan(queQuan);
        }
    }
}