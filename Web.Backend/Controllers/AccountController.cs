using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Web.Backend.Data;
using Web.Backend.Models;

namespace Web.Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       private readonly DataContext _dataContext;

        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpPost("AddBalance")]
        public async Task<IActionResult> AddBalance(decimal balance, int userId)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if(user == null) 
            {
                return NotFound("User not found");
            }

            user.Balance += balance;

            return Ok();
        }

        [HttpPost("NewAccount")]
        public async Task<IActionResult> NewAccount(string currency, int userId)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if(user == null)
                return NotFound();
            var requisites = RandomNumberGenerator.GetInt32(1,int.MaxValue);
            var account = new Account
            {
                Name = $"Account {currency}",
                Currency = currency,
                UserId = userId,
                Requisites = requisites
            };

            await _dataContext.AddAsync(account);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("WithdrawalFunds")]
        public async Task<IActionResult> WithdrawalFunds(decimal ammount, int accountId)
        {
            var account = await _dataContext.Accounts.FindAsync(accountId);
            if(account == null)
                return NotFound("Account not found");

            if(account.Balance < ammount)
                return BadRequest("Account balance less than ammount");

            account.Balance -= ammount;
            await _dataContext.SaveChangesAsync();

            return Ok();
        }


    }
}
