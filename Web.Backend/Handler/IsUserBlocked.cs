using Microsoft.AspNetCore.Authorization;

namespace Web.Backend.Handler
{
    public class IsUserBlocked : IAuthorizationRequirement
    {
        public bool IsBlocked { get; set;}

        public IsUserBlocked(bool isBlocked)
        {
            IsBlocked = isBlocked;
        }
    }
}
