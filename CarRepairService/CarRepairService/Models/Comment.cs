namespace CarRepairService.Models
{
    public class Comment : BaseModel
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
