namespace Web.Backend.Models
{
    public class User : IdentificationModel
    {
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public bool IsBlocked { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
