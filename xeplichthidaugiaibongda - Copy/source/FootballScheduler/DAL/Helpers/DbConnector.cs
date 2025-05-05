using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DAL.Helpers
{
    /// <summary>
    /// Hỗ trợ kết nối và truy vấn SQL Server bằng Dapper.
    /// </summary>
    public static class DbConnector
    {
        private static string _connStr;

        /// <summary>
        /// Thiết lập chuỗi kết nối và kiểm tra kết nối CSDL.
        /// </summary>
        public static void Init(string connStr)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open(); // Kiểm tra kết nối
            }

            _connStr = connStr;
        }

        /// <summary>
        /// Tạo và mở một kết nối mới.
        /// </summary>
        private static SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_connStr);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Thực thi lệnh SQL không trả kết quả (INSERT, UPDATE, DELETE).
        /// </summary>
        public static int Execute(string sql, object parameters = null)
        {
            using (var conn = OpenConnection())
            {
                return conn.Execute(sql, parameters);
            }
        }

        /// <summary>
        /// Thực thi truy vấn và trả về giá trị đơn.
        /// </summary>
        public static object QueryValue(string sql, object parameters = null)
        {
            using (var conn = OpenConnection())
            {
                return conn.ExecuteScalar(sql, parameters);
            }
        }

        /// <summary>
        /// Truy vấn và trả về một dòng (hoặc null).
        /// </summary>
        public static T QuerySingle<T>(string sql, object parameters = null)
        {
            using (var conn = OpenConnection())
            {
                return conn.QuerySingleOrDefault<T>(sql, parameters);
            }
        }

        /// <summary>
        /// Truy vấn và trả về danh sách kết quả.
        /// </summary>
        public static List<T> QueryList<T>(string sql, object parameters = null)
        {
            using (var conn = OpenConnection())
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
        }

        /// <summary>
        /// Truy vấn và trả về DataTable
        /// </summary>
        public static DataTable QueryDataTable(string sql, object parameters = null)
        {
            using (var connection = OpenConnection())
            {
                // Dapper thực hiện truy vấn và trả về SqlDataReader
                using (var reader = connection.ExecuteReader(sql, parameters))
                {
                    // Tạo DataTable và điền dữ liệu vào từ SqlDataReader
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);  // Sử dụng DataTable.Load để điền dữ liệu từ IDataReader

                    return dataTable;
                }
            }
        }

        /// <summary>
        /// Thêm nhiều bản ghi cùng lúc.
        /// </summary>
        public static int BulkInsert<T>(string sql, IEnumerable<T> items)
        {
            using (var conn = OpenConnection())
            {
                return conn.Execute(sql, items);
            }
        }
    }
}
