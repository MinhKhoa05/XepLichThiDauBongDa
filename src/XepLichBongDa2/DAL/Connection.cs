using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Quản lý kết nối và thực thi truy vấn SQL.
    /// </summary>
    public sealed class Connection
    {
        private static readonly Lazy<Connection> _instance = new Lazy<Connection>(() => new Connection());
        private readonly DatabaseFactory _db = new SqlDatabase();

        private string _hostName = ".";
        private readonly string _databaseName = "QuanLyThucTap";
        private string _connString => $"Data Source={_hostName};Initial Catalog={_databaseName};Integrated Security=True;";

        private Connection()
        {
            InitializeConnection();
        }

        /// <summary>
        /// Lấy thể hiện duy nhất của Connection (Singleton Pattern).
        /// </summary>
        public static Connection GetInstance() => _instance.Value;

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE.
        /// </summary>
        /// <param name="sql">Chuỗi truy vấn SQL.</param>
        /// <param name="parameters">Danh sách tham số.</param>
        public void ActionQuery(string sql, params (string, object)[] parameters)
        {
            using (IDbConnection cn = _db.CreateConnection(_connString))
            using (IDbCommand cmd = _db.CreateCommand(sql, cn))
            {
                try
                {
                    cn.Open();
                    AddParameters(cmd, parameters);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw _db.HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về DataTable.
        /// </summary>
        /// <param name="sql">Chuỗi truy vấn SQL.</param>
        /// <param name="parameters">Danh sách tham số.</param>
        /// <returns>DataTable chứa kết quả truy vấn.</returns>
        public DataTable SelectQuery(string sql, params (string, object)[] parameters)
        {
            using (IDbConnection cn = _db.CreateConnection(_connString))
            using (IDbCommand cmd = _db.CreateCommand(sql, cn))
            {
                try
                {
                    cn.Open();
                    AddParameters(cmd, parameters);

                    IDbDataAdapter adapter = _db.CreateDataAdapter(cmd);
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
                }
                catch (Exception ex)
                {
                    throw _db.HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Tạo danh sách tham số cho truy vấn SQL.
        /// </summary>
        public (string, object)[] CreateParameters(params (string, object)[] parameters) => parameters;

        /// <summary>
        /// Thử kết nối với SQL Server (bản thường và bản EXPRESS).
        /// </summary>
        private void InitializeConnection()
        {
            foreach (var host in new[] { ".", @".\SQLEXPRESS" })
            {
                string testConnString = $"Data Source={host};Initial Catalog={_databaseName};Integrated Security=True;";
                try
                {
                    using (IDbConnection cn = _db.CreateConnection(testConnString))
                    {
                        cn.Open();
                        _hostName = host;
                        return;
                    }
                }
                catch
                {
                    continue;
                }
            }
            throw new Exception("Không thể kết nối database.");
        }

        /// <summary>
        /// Thêm tham số vào command.
        /// </summary>
        private static void AddParameters(IDbCommand cmd, params (string, object)[] parameters)
        {
            if (parameters == null) return;

            foreach (var (name, value) in parameters)
            {
                cmd.Parameters.Add(new SqlParameter(name, value ?? DBNull.Value));
            }
        }
    }
}
