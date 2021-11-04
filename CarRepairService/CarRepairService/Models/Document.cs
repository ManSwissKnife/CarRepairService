

namespace CarRepairService.Models
{
    public class Document : BaseModel
    {
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
