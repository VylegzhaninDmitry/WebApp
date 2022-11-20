using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Backend.Data;
using Web.Backend.Models;

namespace Web.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, {currentUser.Login}, you role is {currentUser.Role}");
        }


        [HttpGet("User")]
        [Authorize(Roles = "User")]
        public IActionResult UsersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, {currentUser.Login}, you role is {currentUser.Role}");
        }

        [HttpGet("Public")]

        public IActionResult PublicEndpoint()
        {
            return Ok("Public");
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if (user == null) 
                return NotFound("User not found");

            return Ok(user);
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var user = identity.Claims;

                return new User
                {
                    Login = user.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value!,
                    Role = user.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value!
                };
            }

            return null!;
        }
    }
}
