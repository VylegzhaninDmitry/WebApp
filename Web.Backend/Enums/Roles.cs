using System.ComponentModel;

namespace Web.Backend.Enums
{
    public enum Roles
    {
        [Description("Admin")]
        Admin = 1,
        [Description("User")]
        User = 2,
        [Description("UnautorizeUser")]
        UnauthorizedUser = 3
    }
}
