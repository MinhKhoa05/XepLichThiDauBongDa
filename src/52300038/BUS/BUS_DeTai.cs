using System;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_DeTai
    {
        private readonly DAL_DeTai _dalDeTai = new DAL_DeTai();

        // Thêm Đề tài mới
        public void AddDeTai(string maDT, string tenDT, string chuNhiem, int kinhPhi)
        {
            DTO_DeTai dt = new DTO_DeTai(maDT, tenDT, chuNhiem, kinhPhi);
            _dalDeTai.AddDeTai(dt);
        }

        // Cập nhật thông tin Đề tài
        public void UpdateDeTai(string maDT, string tenDT, string chuNhiem, int kinhPhi)
        {
            DTO_DeTai dt = new DTO_DeTai(maDT, tenDT, chuNhiem, kinhPhi);
            _dalDeTai.UpdateDeTai(dt);
        }

        // Lấy danh sách Đề tài
        public DataTable SelectDeTai()
        {
            return _dalDeTai.SelectDeTai();
        }

        // Lấy Danh sách Mã và Tên Đề tài
        public DataTable SelectMaVaTenDeTai()
        {
            return _dalDeTai.SelectMaVaTenDeTai();
        }

        // Xóa Đề tài theo Mã số
        public void DeleteDeTai(string maDT)
        {
            _dalDeTai.DeleteDeTai(maDT);
        }

        // Lấy danh sách Chủ nhiệm
        public DataTable SelectChuNhiem()
        {
            return _dalDeTai.SelectChuNhiem();
        }
    }
}