namespace CarRepairService.Models
{
    public class Document : BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int WorkerId { get; set; }
        public Worker? Worker { get; set; }
    }
}
