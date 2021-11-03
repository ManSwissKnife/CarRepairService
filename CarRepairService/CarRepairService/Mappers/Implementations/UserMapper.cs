using AutoMapper;
using CarRepairService.Mappers.Interfaces;
using CarRepairService.Models;
using CarRepairService.Models.DTO;

namespace CarRepairService.Mappers.Implementations
{
    public class UserMapper : IMapper<User, UserDTO>
    {
        public void Map(User toUser, UserDTO fromUser)
        {
            toUser.Email = fromUser.IsFieldPresent(nameof(fromUser.Email)) ? fromUser.Email : toUser.Email;
            toUser.Username = fromUser.IsFieldPresent(nameof(fromUser.Login)) ? fromUser.Login : toUser.Username;
            toUser.PasswordHash = fromUser.IsFieldPresent(nameof(fromUser.Password)) ? fromUser.Password : toUser.PasswordHash;
        }

        public void Map(User fromEntity, User toEntity)
        {
            throw new NotImplementedException();
        }
    }
}
