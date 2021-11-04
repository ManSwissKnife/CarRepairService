

namespace CarRepairService.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<User> Users { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
