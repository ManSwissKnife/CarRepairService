using BCryptNet = BCrypt.Net.BCrypt;
using CarRepairService.Database;
using CarRepairService.Mappers.Interfaces;
using CarRepairService.Models;
using CarRepairService.Models.DTO;
using CarRepairService.Models.Users;

namespace CarRepairService.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        Task<User> CreateUserAsync(RegisterRequest model);
        Task<User> UpdateUserAsync(string name, UserDTO user);
        Task<User> GetUserByRefreshTokenAsync(string token);
        Task<User> DeleteUserAsync(AuthenticateRequest user);
        User Update(User user);
        void IncreaseBalance(string name, decimal sum);
    }
    public class SQLUserRepository : IUserRepository
    {
        private readonly IMapper<User, UserDTO> _mapper;
        private readonly CRSContext _db;
        public SQLUserRepository(CRSContext db, IMapper<User, UserDTO> mapper)
        {
            _db = db;
            _mapper = mapper;
         }
        public async Task<User> CreateUserAsync(RegisterRequest model)
        {
            if (await Task.Run(() => _db.Users.Any(u => u.Email == model.Email)))
                return null;
            User user = new User { Email = model.Email, Username = model.Username, PasswordHash = BCryptNet.HashPassword(model.Password), FirstName = model.FirstName, LastName = model.LastName, Balance = 0, Role = "user" };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await Task.Run(() => _db.Users.SingleOrDefault(u => u.Username == username));
        }

        public async Task<User> UpdateUserAsync(string name, UserDTO user)
        {   
            User? toUpdate = await GetUserAsync(name);
            if (toUpdate != null)
            {
                _mapper.Map(toUpdate, user);
                await _db.SaveChangesAsync();
            }
            return toUpdate;
        }

        public async Task<User> DeleteUserAsync(AuthenticateRequest user)
        {
            User? toDelete = await GetUserAsync(user.Username);
            if (toDelete != null || !BCryptNet.Verify(user.Password, toDelete.PasswordHash))
            {
                _db.Remove(toDelete);
                await _db.SaveChangesAsync();
            }
            return toDelete;
        }

        public async Task<User> GetUserByRefreshTokenAsync(string token)
        {
            User? user = await Task.Run(() => _db.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token)));
            return user;
        }

        public User Update(User user)
        {
            var toUpdate = _db.Set<User>().Find(user.Id);
            if (toUpdate != null)
            {
                toUpdate = user;
            }
            _db.Update(toUpdate);
            _db.SaveChanges();
            return toUpdate;
        }

        public async void IncreaseBalance(string name, decimal sum)
        {
            User user = await GetUserAsync(name);
            user.Balance += sum;
            _db.SaveChanges();
        }
    }
}
