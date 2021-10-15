using CarRepairService.Models;
using CarRepairService.Models.DTO;

namespace CarRepairService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string email, string password);
        Task<User> CreateUserAsync(string email, string login, string password);
        Task<User> UpdateUserAsync(string name, UserDTO user);
    }
}
