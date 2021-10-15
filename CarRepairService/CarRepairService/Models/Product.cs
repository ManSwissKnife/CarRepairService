using CarRepairService.Models.Base;

namespace CarRepairService.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
