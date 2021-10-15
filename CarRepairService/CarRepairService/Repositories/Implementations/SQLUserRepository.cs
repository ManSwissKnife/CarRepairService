using CarRepairService.Database;
using CarRepairService.Mappers.Interfaces;
using CarRepairService.Models;
using CarRepairService.Models.DTO;
using CarRepairService.Repositories.Interfaces;

namespace CarRepairService.Repositories.Implementations
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly IMapper<User, UserDTO> _mapper;
        private readonly CRSContext _db;
        public SQLUserRepository(CRSContext db, IMapper<User, UserDTO> mapper)
        {
            _db = db;
            _mapper = mapper;
         }
        public async Task<User> CreateUserAsync(string email, string login, string password)
        {
            if (await Task.Run(() => _db.Users.Any(u => u.Email == email)))
                return null;
            User user = new User { Email = email, Login = login, Password = password, Balance = 0, Role = "user" };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            return await Task.Run(() => _db.Users.SingleOrDefault(u => u.Email == email && u.Password == password));
        }

        public async Task<User> UpdateUserAsync(string name, UserDTO user)
        {   
            User toUpdate = await Task.Run(() => _db.Users.SingleOrDefault(u => u.Email == name));
            if (toUpdate != null)
            {
                _mapper.Map(toUpdate, user);
                await _db.SaveChangesAsync();
            }
            return toUpdate;
        }
    }
}
