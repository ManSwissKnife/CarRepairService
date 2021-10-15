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
            toUser.Login = fromUser.IsFieldPresent(nameof(fromUser.Login)) ? fromUser.Login : toUser.Login;
            toUser.Password = fromUser.IsFieldPresent(nameof(fromUser.Password)) ? fromUser.Password : toUser.Password;
        }
    }
}
