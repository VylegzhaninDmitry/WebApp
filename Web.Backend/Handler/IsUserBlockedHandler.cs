using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Web.Backend.Models;

namespace Web.Backend.Handler
{
    public class IsUserBlockedHandler : AuthorizationHandler<IsUserBlocked>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsUserBlocked requirement)
        {
            if (context.User.HasClaim(f => f.Type == "IsBlocked"))
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
