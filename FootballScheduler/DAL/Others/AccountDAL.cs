using DAL.Helpers;
using DTO;

namespace DAL.Others
{
    public class AccountDAL
    {
        public bool IsAccountExist(string username)
        {
            const string sql = "SELECT COUNT(*) FROM Account WHERE UserName = @UserName";
            return (int)DbConnector.QueryValue(sql, new { UserName = username }) > 0;
        }

        public AccountDTO Login(string username, string password)
        {
            const string sql = "SELECT * FROM Account WHERE UserName = @Username AND PasswordHash = @Password";
            return DbConnector.QuerySingle<AccountDTO>(sql, new { Username = username, Password = password });
        }

        public AccountDTO GetById(string accountId)
        {
            const string sql = "SELECT * FROM Account WHERE AccountID = @AccountId";
            return DbConnector.QuerySingle<AccountDTO>(sql, new { AccountId = accountId });
        }

        public void Insert(AccountDTO account)
        {
            const string sql = "INSERT INTO Account (AccountID, UserName, PasswordHash, Role) VALUES (@AccountID, @UserName, @PasswordHash, @Role)";
            DbConnector.Execute(sql, account);
        }

        public void Update(AccountDTO account)
        {
            const string sql = "UPDATE Account SET UserName = @UserName, PasswordHash = @PasswordHash, Role = @Role WHERE AccountID = @AccountID";
            DbConnector.Execute(sql, account);
        }
    }
}
