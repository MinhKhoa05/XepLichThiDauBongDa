using DTO;
using System;
using System.Data;

namespace DAL
{
    public class DAL_DeTai
    {
        private readonly Connection _cn = Connection.GetInstance();

        // Thêm Đề tài
        public void AddDeTai(DTO_DeTai dt)
        {
            string query = "INSERT INTO DeTai (MaDT, TenDT, ChuNhiem, KinhPhi) " +
                           "VALUES (@MaDT, @TenDT, @ChuNhiem, @KinhPhi)";

            var parameters = _cn.CreateParameters (
                ("@MaDT", dt.MaDT),
                ("@TenDT", dt.TenDT),
                ("@ChuNhiem", dt.ChuNhiem),
                ("@KinhPhi", dt.KinhPhi)
            );

            _cn.ActionQuery(query, parameters);
        }

        // Cập nhật Đề tài
        public void UpdateDeTai(DTO_DeTai dt)
        {
            string query = "UPDATE DeTai " +
                           "SET TenDT = @TenDT, ChuNhiem = @ChuNhiem, KinhPhi = @KinhPhi " +
                           "WHERE MaDT = @MaDT";

            var parameters = _cn.CreateParameters (
                ("@TenDT", dt.TenDT),
                ("@ChuNhiem", dt.ChuNhiem),
                ("@KinhPhi", dt.KinhPhi),
                ("@MaDT", dt.MaDT)
            );

            _cn.ActionQuery(query, parameters);
        }

        // Xóa Đề tài
        public void DeleteDeTai(string maDT)
        {
            string query = "DELETE FROM DeTai WHERE MaDT = @MaDT";

            var parameters = _cn.CreateParameters (
                ("@MaDT", maDT)
            );

            _cn.ActionQuery(query, parameters);
        }

        // Lấy danh sách Đề tài
        public DataTable SelectDeTai()
        {
            string query = "SELECT * FROM DeTai";
            return _cn.SelectQuery(query);
        }

        // Lấy danh sách mã và Tên Đề tài
        public DataTable SelectMaVaTenDeTai()
        {
            string query = "SELECT MaDT, TenDT FROM DeTai";
            return _cn.SelectQuery(query);
        }

        // Lấy danh sách chủ nhiệm
        public DataTable SelectChuNhiem()
        {
            string query = "SELECT DISTINCT ChuNhiem FROM DeTai";
            return _cn.SelectQuery(query);
        }
    }
}