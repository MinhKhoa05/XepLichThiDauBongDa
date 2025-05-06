using System;
using DTO;
using DAL;

namespace BUS.BUSs
{
    public class AccountBUS
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();

        public AccountDTO GetById(string accountId)
        {
            return _accountDAL.GetById(accountId);
        }

        public AccountDTO Login(string username, string password)
        {
            // Kiểm tra tài khoản có tồn tại không
            if (!_accountDAL.IsAccountExist(username))
            {
                throw new InvalidOperationException("Tài khoản không tồn tại!");
            }

            // Kiểm tra trong DB
            var loginAccount = _accountDAL.Login(username, password);
            
            if (loginAccount == null)
            {
                throw new InvalidOperationException("Mật khẩu sai!");
            }

            return loginAccount;
        }

        public void Update(AccountDTO account)
        {
            _accountDAL.Update(account);
        }
    }
}