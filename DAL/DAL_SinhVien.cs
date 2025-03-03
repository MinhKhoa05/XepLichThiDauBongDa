using DTO;
using System;
using System.Data;

namespace DAL
{
    public class DAL_SinhVien
    {
        private readonly IDBConnection _db = SqlDBConnection.GetInstance();

        // Thêm Sinh viên
        public void AddSinhVien(DTO_SinhVien sv)
        {
            string query = "INSERT INTO SinhVien (MaSV, HoTen, QueQuan, NgaySinh, HocLuc) " +
                           "VALUES (@MaSV, @HoTen, @QueQuan, @NgaySinh, @HocLuc)";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@MaSV", sv.MaSV),
                _db.CreateParameter("@HoTen", sv.HoTen),
                _db.CreateParameter("@QueQuan", sv.QueQuan),
                _db.CreateParameter("@NgaySinh", sv.NgaySinh),
                _db.CreateParameter("@HocLuc", sv.HocLuc)
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

        // Cập nhật Sinh viên
        public void UpdateSinhVien(DTO_SinhVien sv)
        {
            string query = "UPDATE SinhVien " +
                           "SET HoTen = @HoTen, QueQuan = @QueQuan, NgaySinh = @NgaySinh, HocLuc = @HocLuc " +
                           "WHERE MaSV = @MaSV";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@HoTen", sv.HoTen),
                _db.CreateParameter("@QueQuan", sv.QueQuan),
                _db.CreateParameter("@NgaySinh", sv.NgaySinh),
                _db.CreateParameter("@HocLuc", sv.HocLuc),
                _db.CreateParameter("@MaSV", sv.MaSV)
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

        // Xóa sinh viên
        public void DeleteSinhVien(string maSV)
        {
            string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

            IDataParameter[] parameters =
            {
                _db.CreateParameter("@MaSV", maSV)
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
        
        // Lấy danh sách sinh viên
        public DataTable SelectSinhVien()
        {
            string query = "SELECT * FROM SinhVien";

            try
            {
                return _db.SelectQuery(query);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Lấy danh sách mã và họ tên Sinh viên
        public DataTable SelectMaVaTenSinhVien()
        {
            string query = "SELECT MaSV, HoTen FROM SinhVien";

            try
            {
                return _db.SelectQuery(query);
            }
            catch (Exception ex)
            {
                throw _db.HandleException(ex);
            }
        }

        // Lấy danh sách quê quán
        public DataTable SelectQueQuan()
        {
            string query = "SELECT DISTINCT QueQuan FROM SinhVien";

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