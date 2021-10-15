using CarRepairService.Models;
using CarRepairService.Models.DTO;
using CarRepairService.Repositories.Interfaces;
using CarRepairService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRepairService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepairService _repairService;
        private readonly IUserRepository _users;
        private readonly IRepository<User, UserDTO> _tUsers;
        public UsersController(IRepairService repairService, IUserRepository users, IRepository<User, UserDTO> tUsers)
        {
            _repairService = repairService;
            _users = users;
            _tUsers = tUsers;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (email == null || password == null)
                return BadRequest();
            IActionResult result = await _repairService.GetToken(email, password);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(string email, string login, string password)
        {
            if (email == null || login == null || password == null)
                return BadRequest();
            User user = await _users.CreateUserAsync(email, login, password);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        [Authorize]
        [HttpPatch]
        public async Task<ActionResult<User>> Patch(UserDTO user)
        {
            if (user == null)
                return BadRequest();
            string name = User.Identity.Name;
            User updateUser = await _users.UpdateUserAsync(name, user);
            if (updateUser == null)
                return NotFound();
            return Ok(updateUser);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> Delete(int id)
        //{
        //    User user = await _users.DeleteAsync(id);
        //    if (user == null)
        //        return NotFound();
        //    return Ok(user);
        //}

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _tUsers.GetListAsync();
        }

        [Authorize(Roles = "admin")]
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
