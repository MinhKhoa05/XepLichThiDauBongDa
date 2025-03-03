using DTO;
using System;
using System.Data;

namespace DAL
{
    public class DAL_DeTai
    {
        private readonly IDBConnection _db = SqlDBConnection.GetInstance();

        // Thêm Đề tài
        public void AddDeTai(DTO_DeTai dt)
        {
            string query = "INSERT INTO DeTai (MaDT, TenDT, ChuNhiem, KinhPhi) " +
                           "VALUES (@MaDT, @TenDT, @ChuNhiem, @KinhPhi)";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@MaDT", dt.MaDT),
                _db.CreateParameter("@TenDT", dt.TenDT),
                _db.CreateParameter("@ChuNhiem", dt.ChuNhiem),
                _db.CreateParameter("@KinhPhi", dt.KinhPhi)
            };

            try
            {
                _db.ActionQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Cập nhật Đề tài
        public void UpdateDeTai(DTO_DeTai dt)
        {
            string query = "UPDATE DeTai " +
                           "SET TenDT = @TenDT, ChuNhiem = @ChuNhiem, KinhPhi = @KinhPhi " +
                           "WHERE MaDT = @MaDT";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@TenDT", dt.TenDT),
                _db.CreateParameter("@ChuNhiem", dt.ChuNhiem),
                _db.CreateParameter("@KinhPhi", dt.KinhPhi),
                _db.CreateParameter("@MaDT", dt.MaDT)
            };

            try
            {
                _db.ActionQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Xóa Đề tài
        public void DeleteDeTai(string maDT)
        {
            string query = "DELETE FROM DeTai WHERE MaDT = @MaDT";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@MaDT", maDT)
            };

            try
            {
                _db.ActionQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Lấy danh sách Đề tài
        public DataTable SelectDeTai()
        {
            string query = "SELECT * FROM DeTai";

            try
            {
                return _db.SelectQuery(query);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }


        // Lấy danh sách mã và Tên Đề tài
        public DataTable SelectMaVaTenDeTai()
        {
            string query = "SELECT MaDT, TenDT FROM DeTai";

            try
            {
                return _db.SelectQuery(query);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Lấy danh sách chủ nhiệm
        public DataTable SelectChuNhiem()
        {
            string query = "SELECT DISTINCT ChuNhiem FROM DeTai";

            try
            {
                return _db.SelectQuery(query);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }
    }
}