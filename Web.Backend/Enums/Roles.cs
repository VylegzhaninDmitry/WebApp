using System.ComponentModel;

namespace Web.Backend.Enums
{
    public enum Roles
    {
        [Description("User")]
        Admin = 1,
        [Description("User")]
        User = 2,
    }
}
