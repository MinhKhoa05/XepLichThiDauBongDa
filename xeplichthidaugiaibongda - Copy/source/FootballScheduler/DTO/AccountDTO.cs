using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class AccountDTO
    {
        [Key]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập phải từ 4 đến 50 ký tự")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Chỉ cho phép chữ, số và dấu gạch dưới")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 50 ký tự")]
        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public AccountDTO() { }

        public AccountDTO(int accountID, string userName, string passwordHash)
        {
            AccountID = accountID;
            UserName = userName;
            PasswordHash = passwordHash;
        }

        public AccountDTO(int accountID, string userName, string passwordHash, string role)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}