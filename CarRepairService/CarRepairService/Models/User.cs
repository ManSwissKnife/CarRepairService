using CarRepairService.Models.Base;

namespace CarRepairService.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public decimal Balance { get; set; }
    }
}
