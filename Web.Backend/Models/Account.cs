namespace Web.Backend.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int Requisites { get; set; }
    }
}
