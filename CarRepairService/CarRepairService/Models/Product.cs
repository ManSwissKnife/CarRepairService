

namespace CarRepairService.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
