using System;
using System.Data;

namespace DAL
{
    /// <summary>
    /// Lớp cơ sở trừu tượng để tạo các thành phần cơ bản của database.
    /// </summary>
    public abstract class DatabaseFactory
    {
        /// <summary>
        /// Tạo một đối tượng <see cref="IDbCommand"/> từ câu lệnh SQL.
        /// </summary>
        /// <param name="sql">Câu lệnh SQL.</param>
        /// <returns>Đối tượng <see cref="IDbCommand"/>.</returns>
        public abstract IDbCommand CreateCommand(string sql);

        /// <summary>
        /// Tạo một đối tượng <see cref="IDbCommand"/> với kết nối cụ thể.
        /// </summary>
        /// <param name="sql">Câu lệnh SQL.</param>
        /// <param name="cn">Đối tượng kết nối <see cref="IDbConnection"/>.</param>
        /// <returns>Đối tượng <see cref="IDbCommand"/>.</returns>
        public abstract IDbCommand CreateCommand(string sql, IDbConnection connection);

        /// <summary>
        /// Tạo một kết nối đến cơ sở dữ liệu.
        /// </summary>
        /// <param name="cnString">Chuỗi kết nối.</param>
        /// <returns>Đối tượng <see cref="IDbConnection"/>.</returns>
        public abstract IDbConnection CreateConnection(string connectionString);

        /// <summary>
        /// Tạo một đối tượng <see cref="IDbDataAdapter"/> từ lệnh SELECT.
        /// </summary>
        /// <param name="selectCmd">Câu lệnh SELECT.</param>
        /// <returns>Đối tượng <see cref="IDbDataAdapter"/>.</returns>
        public abstract IDbDataAdapter CreateDataAdapter(IDbCommand selectCommand);

        /// <summary>
        /// Tạo một tham số cho truy vấn SQL.
        /// </summary>
        /// <param name="name">Tên tham số.</param>
        /// <param name="value">Giá trị tham số.</param>
        /// <returns>Đối tượng <see cref="IDbDataParameter"/>.</returns>
        public abstract IDbDataParameter CreateDataParameter(string name, object value);

        /// <summary>
        /// Xử lý và ánh xạ lỗi SQL thành Exception dễ hiểu hơn.
        /// </summary>
        /// <param name="ex">Ngoại lệ gốc.</param>
        /// <returns>Đối tượng <see cref="Exception"/> đã xử lý.</returns>
        public abstract Exception HandleException(Exception ex);
    }
}