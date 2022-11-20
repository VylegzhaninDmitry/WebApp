using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Backend.Data;
using Web.Backend.Enums;
using Web.Backend.Filter;
using Web.Backend.Models;
using Web.Backend.Wrapper;

namespace Web.Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AdminController(DataContext dataContext) 
        {
            _dataContext= dataContext;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _dataContext.Users
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _dataContext.Users.CountAsync();
            return Ok(new PagedResponse<List<User>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords));
        }

        [HttpPost("BlockUser")]
        public async Task<IActionResult> BlockUser([FromBody] int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if(user == null)
                return NotFound("User not found");

            user.IsBlocked = !user.IsBlocked;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return Ok();
        }

        [HttpPost("VerifiedUser")]
        public async Task<IActionResult> VerifiedUser([FromBody] int id)
        {
            var user = await _dataContext.Users.FindAsync(id);

            if(user == null)
                return NotFound("User not found");

            user.IsVerified = !user.IsVerified;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return Ok();
        }

    }
}
