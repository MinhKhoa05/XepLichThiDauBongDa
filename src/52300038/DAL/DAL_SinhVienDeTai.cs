using DTO;
using System;
using System.Data;

namespace DAL
{
    public class DAL_SinhVienDeTai
    {
        private readonly IDBConnection _db = SqlDBConnection.GetInstance();

        // Thêm Kết quả thực tập
        public void AddSinhVienDeTai(DTO_SinhVienDeTai svdt)
        {
            string query = "INSERT INTO SinhVien_DeTai (MaSV, MaDT, NoiThucTap, QuangDuong, KetQua) " +
                           "VALUES (@MaSV, @MaDT, @NoiThucTap, @QuangDuong, @KetQua)";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@MaSV", svdt.MaSV),
                _db.CreateParameter("@MaDT", svdt.MaDT),
                _db.CreateParameter("@NoiThucTap", svdt.NoiThucTap),
                _db.CreateParameter("@QuangDuong", svdt.QuangDuong),
                _db.CreateParameter("@KetQua", svdt.KetQua)
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

        // Cập nhật Kết quả thực tập
        public void UpdateSinhVienDeTai(DTO_SinhVienDeTai svdt)
        {
            string query = "UPDATE SinhVien_DeTai " +
                           "SET NoiThucTap = @NoiThucTap, QuangDuong = @QuangDuong, KetQua = @KetQua " +
                           "WHERE MaSV = @MaSV AND MaDT = @MaDT";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@NoiThucTap", svdt.NoiThucTap),
                _db.CreateParameter("@QuangDuong", svdt.QuangDuong),
                _db.CreateParameter("@KetQua", svdt.KetQua),
                _db.CreateParameter("@MaSV", svdt.MaSV),
                _db.CreateParameter("@MaDT", svdt.MaDT)
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

        // Xóa kết quả thực tập
        public void DeleteSinhVienDeTai(string maSV, string maDT)
        {
            string query = "DELETE FROM SinhVien_DeTai WHERE MaSV = @MaSV AND MaDT = @MaDT";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@MaSV", maSV),
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

        // Lấy danh sách Kết quả thực tập
        public DataTable SelectSinhVienDeTai()
        {
            string query = @"
                SELECT svdt.MaSV, sv.HoTen, svdt.MaDT, dt.TenDT, svdt.NoiThucTap, svdt.QuangDuong, svdt.KetQua
                FROM SinhVien_DeTai svdt
                JOIN SinhVien sv ON svdt.MaSV = sv.MaSV
                JOIN DeTai dt ON svdt.MaDT = dt.MaDT";

            try
            {
                return _db.SelectQuery(query);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Lấy danh sách nơi thực tập
        public DataTable SelectNoiThucTap()
        {
            string query = "SELECT DISTINCT NoiThucTap FROM SinhVien_DeTai";

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