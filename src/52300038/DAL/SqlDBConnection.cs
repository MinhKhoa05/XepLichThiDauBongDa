using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public sealed class SqlDBConnection : IDBConnection
    {
        private static readonly Lazy<SqlDBConnection> _instance =
            new Lazy<SqlDBConnection>(() => new SqlDBConnection());

        private readonly string _connString;

        private SqlDBConnection()
        {
            _connString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
        }

        public static SqlDBConnection GetInstance() => _instance.Value;

        public void ActionQuery(string sql, IDataParameter[] parameters = null)
        {
            using (SqlConnection cn = new SqlConnection(_connString))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                try
                {
                    cn.Open();
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw HandleException(ex);
                }
            }
        }

        public DataTable SelectQuery(string sql, IDataParameter[] parameters = null)
        {
            using (SqlConnection cn = new SqlConnection(_connString))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                try
                {
                    cn.Open();
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw HandleException(ex);
                }
            }
        }

        public IDataParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        public Exception HandleException(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                switch (sqlEx.Number)
                {
                    case 2627:
                        return new Exception("Khóa chính đã tồn tại.", ex);
                    case 547:
                        return new Exception("Không thể xóa dữ liệu do ràng buộc.", ex);
                }
            }
            return new Exception("Lỗi SQL Server: " + ex.Message, ex);
        }
    }
}
