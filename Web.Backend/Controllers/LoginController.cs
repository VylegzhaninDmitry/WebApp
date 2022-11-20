using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Web.Backend.Data;
using Web.Backend.Enums;
using Web.Backend.Models;

namespace Web.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<LoginController> _logger;
        private readonly DataContext _dataContext;

        public LoginController(IConfiguration config, ILogger<LoginController> logger, DataContext dataContext)
        {
            _config = config;
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register(UserLogin userLogin)
        {
            var (passwordHash, passwordSalt) = GetNewPassword(userLogin.Password);
            //todo return change without hash salt
            var user = new User
            {
                Login = userLogin.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Roles.UnauthorizedUser.ToString(),
                IsVerified = false,
                IsBlocked = false
            };

            _dataContext.Add(user);
            _dataContext.SaveChanges();

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user == null)
                return NotFound("User not found!");

            if (!VerifyPasswordHash(userLogin.Password, user.PasswordSalt, user.PasswordHash))
                return BadRequest("Wrong password!");

            if (user.Role == Roles.UnauthorizedUser.ToString())
                return BadRequest("You are not an authorized user yet!");

            var token = Generate(user);
            return Ok(token);

        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Login),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = _dataContext.Users.FirstOrDefault(u => u.Login.ToLower() == userLogin.Username.ToLower());

            if (currentUser != null)
            {
                return currentUser;
            }

            return null!;
        }


        private static byte[] GenerateSalt()
        {
            var salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }

        private (string hash, string salt) GetNewPassword(string input)
        {
            var salt = GenerateSalt();
            var hashed = HashPassword(input, salt);
            return (hashed, Convert.ToBase64String(salt));
        }

        private static string HashPassword(string input, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));
        }


        private bool VerifyPasswordHash(string password, string passwordSalt, string passwordHash)
        {
            var providedHashed = HashPassword(password, Convert.FromBase64String(passwordSalt));
            return string.Equals(passwordHash, providedHashed, StringComparison.Ordinal);
        }
    }
}
