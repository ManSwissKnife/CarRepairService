using Newtonsoft.Json;

namespace CarRepairService.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string Role { get; set; }
        public decimal Balance { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
