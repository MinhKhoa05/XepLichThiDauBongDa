using System;
using System.IO;
using DAL;

namespace BUS.Managers
{
    /// <summary>
    /// Quản lý cấu hình kết nối đến cơ sở dữ liệu.
    /// </summary>
    public static class DbConfigManager
    {
        private const string ConfigPath = "config.txt";
        private static string _connStr;

        // Tự động load và kiểm tra kết nối khi app khởi chạy
        static DbConfigManager()
        {
            try { LoadAndTest(); } catch { } // Không xử lý lỗi ở đây, chỉ quăng ra ngoài
        }

        /// <summary>
        /// Đọc chuỗi kết nối từ file cấu hình (1 dòng duy nhất) và kiểm tra kết nối.
        /// </summary>
        public static bool LoadAndTest()
        {
            if (!File.Exists(ConfigPath))
                throw new FileNotFoundException(); // Chỉ quăng lỗi mà không cần thông báo chi tiết

            _connStr = File.ReadAllText(ConfigPath).Trim();

            if (string.IsNullOrEmpty(_connStr))
                throw new InvalidDataException(); // Chỉ quăng lỗi mà không cần thông báo chi tiết

            return Test();
        }

        /// <summary>
        /// Tạo chuỗi kết nối mới và lưu nếu hợp lệ.
        /// </summary>
        public static void SetAndSave(bool winAuth, string server, string db, string user, string pass)
        {
            _connStr = Build(winAuth, server, db, user, pass);
            if (Test()) Save();
        }

        /// <summary>
        /// Xây dựng chuỗi kết nối từ thông tin đầu vào.
        /// </summary>
        private static string Build(bool winAuth, string server, string db, string user, string pass)
        {
            var str = $"Data Source={server};Initial Catalog={db};";
            str += winAuth ? "Integrated Security=True;" : $"User ID={user};Password={pass};";
            return str + "Connection Timeout=2;Pooling=false";
        }

        /// <summary>
        /// Kiểm tra khả năng kết nối đến CSDL.
        /// </summary>
        private static bool Test()
        {
            try
            {
                DbConnector.Init(_connStr);
                return true;
            }
            catch
            {
                throw new Exception("Lỗi kết nối. Vui lòng kiểm tra lại thông tin!");
            }
        }

        /// <summary>
        /// Lưu chuỗi kết nối vào file nếu có thay đổi.
        /// </summary>
        private static void Save()
        {
            if (!File.Exists(ConfigPath) || File.ReadAllText(ConfigPath) != _connStr)
                File.WriteAllText(ConfigPath, _connStr);
        }
    }
}
