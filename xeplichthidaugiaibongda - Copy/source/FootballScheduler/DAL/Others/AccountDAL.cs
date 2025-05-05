using DAL.Helpers;
using DTO;

namespace DAL.Others
{
    public class AccountDAL
    {
        #region GET Methods  

        public bool IsAccountExist(string username)
        {
            const string sql = "SELECT COUNT(*) FROM Account WHERE UserName = @UserName";
            return (int)DbConnector.QueryValue(sql, new { UserName = username }) > 0;
        }

        #endregion

        #region Authentication Methods  

        /// <summary>  
        /// Xác thực tài khoản khi đăng nhập.  
        /// </summary>  
        public AccountDTO GetAccountForLogin(string username, string password)
        {
            const string sql = "SELECT * FROM Account WHERE UserName = @Username AND PasswordHash = @Password";
            return DbConnector.QuerySingle<AccountDTO>(sql, new { Username = username, Password = password });
        }

        #endregion

        #region GET Methods  

        /// <summary>  
        /// Lấy thông tin tài khoản theo ID.  
        /// </summary>  
        /// <param name="accountId">ID của tài khoản cần lấy</param>  
        /// <returns>AccountDTO nếu tìm thấy, null nếu không tồn tại</returns>  
        public AccountDTO GetAccountById(int accountId)
        {
            const string sql = "SELECT * FROM Account WHERE AccountID = @AccountId";
            return DbConnector.QuerySingle<AccountDTO>(sql, new { AccountId = accountId });
        }

        /// <summary>  
        /// Lấy mật khẩu (PasswordHash) của tài khoản theo UserName.  
        /// </summary>  
        /// <param name="username">Tên đăng nhập</param>  
        /// <returns>PasswordHash nếu tồn tại, null nếu không tìm thấy</returns>  
        public string GetPasswordByUsername(string username)
        {
            const string sql = "SELECT PasswordHash FROM Account WHERE UserName = @Username";
            var result = DbConnector.QueryValue(sql, new { Username = username });
            return result != null ? result.ToString() : null;
        }

        #endregion

        #region Update Methods  

        /// <summary>  
        /// Cập nhật mật khẩu mới cho tài khoản sau khi kiểm tra tài khoản có tồn tại.  
        /// </summary>  
        /// <param name="username">Tên đăng nhập của tài khoản</param>  
        /// <param name="newPassword">Mật khẩu mới (đã băm nếu có)</param>  
        /// <returns>True nếu cập nhật thành công, ngược lại False</returns>  
        public bool UpdatePassword(string username, string newPassword)
        {
            // Kiểm tra tài khoản có tồn tại không  
            if (!IsAccountExist(username))
                return false;

            // Thực hiện cập nhật mật khẩu  
            const string sql = "UPDATE Account SET PasswordHash = @Password WHERE UserName = @Username";
            int rowsAffected = DbConnector.Execute(sql, new { Username = username, Password = newPassword });
            return rowsAffected > 0;
        }

        #endregion
    }
}
