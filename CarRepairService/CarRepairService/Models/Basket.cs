namespace CarRepairService.Models
{
    public class Basket : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
