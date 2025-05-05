using System;
using BUS.Helpers;
using DAL.Others;
using DTO;

namespace BUS.Others
{
    public class AccountBUS
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();

        public AccountDTO GetAccountById(int accountId)
        {
            // Kiểm tra ID hợp lệ
            if (accountId <= 0)
            {
                throw new ArgumentException("ID tài khoản không hợp lệ!");
            }

            // Gọi phương thức DAL để lấy thông tin tài khoản
            var account = _accountDAL.GetAccountById(accountId);

            // Kiểm tra kết quả
            if (account == null)
            {
                throw new InvalidOperationException($"Không tìm thấy tài khoản với ID {accountId}!");
            }

            return account;
        }


        public AccountDTO CheckLogin(string username, string password)
        {
            var inputAccount = new AccountDTO(0, username, password);

            // Validation dữ liệu đầu vào
            if (!ValidatorHelper.TryValidate(inputAccount, out var errors))
            {
                throw new Exception(errors);
            }

            // Kiểm tra tài khoản có tồn tại không
            if (!_accountDAL.IsAccountExist(username))
            {
                throw new InvalidOperationException("Tài khoản không tồn tại!");
            }

            // Kiểm tra trong DB
            var loginAccount = _accountDAL.GetAccountForLogin(username, password);

            if (loginAccount == null)
            {
                throw new InvalidOperationException("Mật khẩu sai!");
            }

            return loginAccount;
        }


        public AccountDTO GetAccountForLogin(string username, string password)
        {
            // Gọi phương thức DAL để truy vấn thông tin tài khoản
            var account = _accountDAL.GetAccountForLogin(username, password);

            if (account == null)
            {
                throw new InvalidOperationException("Tài khoản hoặc mật khẩu không chính xác!");
            }

            return account;
        }
        public string GetPasswordByUsername(string username)
        {
            // Kiểm tra tài khoản có tồn tại trước khi lấy mật khẩu
            if (!_accountDAL.IsAccountExist(username))
            {
                throw new InvalidOperationException("Tài khoản không tồn tại!");
            }

            // Lấy mật khẩu từ DAL
            var password = _accountDAL.GetPasswordByUsername(username);

            // Kiểm tra nếu mật khẩu không tồn tại (trường hợp bất thường)
            if (password == null)
            {
                throw new Exception("Mật khẩu sai!");
            }

            return password;
        }


        public void UpdatePassword(string username, string newPassword)
        {
            // Tạo đối tượng AccountDTO để xác thực dữ liệu đầu vào
            var inputAccount = new AccountDTO(0, username, newPassword);

            // Kiểm tra dữ liệu hợp lệ (có thể kiểm tra username và password theo quy định riêng)
            if (!ValidatorHelper.TryValidate(inputAccount, out var errors))
            {
                throw new Exception(errors);
            }

            // Kiểm tra tài khoản có tồn tại không
            if (!_accountDAL.IsAccountExist(username))
            {
                throw new InvalidOperationException("Tài khoản không tồn tại!");
            }

            // Thực hiện cập nhật mật khẩu
            var success = _accountDAL.UpdatePassword(username, newPassword);

            if (!success)
            {
                throw new Exception("Cập nhật mật khẩu thất bại!");
            }
        }





    }
}