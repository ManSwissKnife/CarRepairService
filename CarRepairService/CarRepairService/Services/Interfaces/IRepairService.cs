using CarRepairService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRepairService.Services.Interfaces
{
    public interface IRepairService
    {
        public Task<IActionResult> GetToken(string login, string password);
    }
}
