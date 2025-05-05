namespace DTO
{
    public class AccountDTO
    {
        public string AccountID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public AccountDTO() { }

        public AccountDTO(string userName, string passwordHash)
        {
            UserName = userName;
            PasswordHash = passwordHash;
        }
    }
}