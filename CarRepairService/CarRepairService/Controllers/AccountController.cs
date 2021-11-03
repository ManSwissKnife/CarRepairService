﻿using CarRepairService.Models;
using CarRepairService.Models.DTO;
using CarRepairService.Models.Users;
using CarRepairService.Repositories;
using CarRepairService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRepairService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _users;
        private readonly IRepository<User, UserDTO> _tUsers;
        public AccountController(IUserService userService, IUserRepository users, IRepository<User, UserDTO> tUsers)
        {
            _userService = userService;
            _users = users;
            _tUsers = tUsers;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            AuthenticateResponse response = await _userService.Authenticate(model, IpAddress());
            if (response == null)
                return NotFound();
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterRequest model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                User user = await _users.CreateUserAsync(model);
                if (user == null)
                    return BadRequest();
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            string refreshToken = Request.Cookies["refreshToken"];
            AuthenticateResponse response = await _userService.RefreshToken(refreshToken, IpAddress());
            if (response == null)
                return BadRequest(new { errorText = "Invalid refresh token." });
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(string? Token)
        {
            // accept refresh token in request body or cookie
            var token = Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            _userService.RevokeToken(token, IpAddress());
            return Ok(new { message = "Token revoked" });
        }

        [Authorize]
        [HttpPatch]
        public async Task<ActionResult<User>> Update(UserDTO user)
        {
            if (user == null)
                return BadRequest();
            string name = User.Identity.Name;
            User toUpdateUser = await _users.UpdateUserAsync(name, user);
            if (toUpdateUser == null)
                return NotFound();
            return Ok(toUpdateUser);
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<User>> Delete(string password)
        {
            AuthenticateRequest user = new() { Username = User.Identity.Name, Password = password };
            User toDeleteUser = await _users.DeleteUserAsync(user);
            if (user == null)
                return NotFound();
            return Ok(toDeleteUser);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            User user = await _users.GetUserAsync(User.Identity.Name);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
        [Authorize]
        [HttpPost("increase-balance")]
        public async Task<ActionResult<User>> IncreaseBalance(decimal sum)
        {
            _users.IncreaseBalance(User.Identity.Name, sum);
            return Ok();
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
