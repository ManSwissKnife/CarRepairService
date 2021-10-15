using CarRepairService.Models.Base;

namespace CarRepairService.Models.DTO
{
    public class UserDTO : BaseModel
    {
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
