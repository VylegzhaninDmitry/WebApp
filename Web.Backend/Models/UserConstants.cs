namespace Web.Backend.Models
{
    public class UserConstants
    {
        public static List<User> users = new()
        {
            new User()
            {
                Login = "admin",
                Email = "admin@example.com",
                Role = "Administrator",
            },
            new User()
            {
                Login = "user",
                Email = "user@example.com",
                Role = "User",
            }
        };
    }
}
