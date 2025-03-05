using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Lớp SqlDatabase cung cấp các phương thức tạo kết nối, lệnh SQL và xử lý ngoại lệ.
    /// </summary>
    public class SqlDatabase : DatabaseFactory
    {
        /// <inheritdoc/>
        public override IDbCommand CreateCommand(string sql) => new SqlCommand(sql);

        /// <inheritdoc/>
        public override IDbCommand CreateCommand(string sql, IDbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            return new SqlCommand(sql, (SqlConnection)connection);
        }

        /// <inheritdoc/>
        public override IDbConnection CreateConnection(string connectionString) => new SqlConnection(connectionString);

        /// <inheritdoc/>
        public override IDbDataAdapter CreateDataAdapter(IDbCommand selectCommand) => new SqlDataAdapter((SqlCommand)selectCommand);

        /// <inheritdoc/>
        public override IDbDataParameter CreateDataParameter(string name, object value) => new SqlParameter(name, value ?? DBNull.Value);

        /// <inheritdoc/>
        public override Exception HandleException(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                string er = "Lỗi Sql Server: ";
                switch (sqlEx.Number)
                {
                    case 2627:
                        return new Exception(er + "Dữ liệu đã tồn tại, vui lòng kiểm tra lại.", sqlEx);

                    case 547:
                        return new Exception(er + "Không thể xóa hoặc cập nhật dữ liệu do ràng buộc khóa ngoại.", sqlEx);

                    case 208:
                        return new Exception(er + "Bảng dữ liệu không tồn tại.", sqlEx);

                    case 18456:
                        return new Exception(er + "Đăng nhập thất bại! Vui lòng kiểm tra tài khoản và mật khẩu.", sqlEx);

                    case 1205:
                        return new Exception(er + "Hệ thống đang bận, vui lòng thử lại sau.", sqlEx);

                    default:
                        return new Exception(er + $"Lỗi SQL ({sqlEx.Number}): {sqlEx.Message}", sqlEx);
                }
            }

            // Nếu không phải SqlException, trả về lỗi mặc định
            return new Exception("Lỗi hệ thống: " + ex.Message, ex);
        }
    }
}
