using CarRepairService.Models;
using CarRepairService.Models.DTO;
using CarRepairService.Models.Users;
using CarRepairService.Repositories;
using CarRepairService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRepairService.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _users;
        private readonly IRepository<User, UserDTO> _tUsers;
        public UsersController(IUserService userService, IUserRepository users, IRepository<User, UserDTO> tUsers)
        {
            _userService = userService;
            _users = users;
            _tUsers = tUsers;
        }

        [HttpGet("{id}/refresh-tokens")]
        public async Task<IActionResult> GetRefreshTokens(int id)
        {
            User user = await _tUsers.GetAsync(id);
            return Ok(user.RefreshTokens);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = await _tUsers.DeleteAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _tUsers.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await _tUsers.GetAsync(id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
    }
}
