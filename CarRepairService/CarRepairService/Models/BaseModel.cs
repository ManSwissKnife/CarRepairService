using CarRepairService.PatchRequestContractResolver;

namespace CarRepairService.Models
{
    public class BaseModel : PatchDtoBase
    {
        public int Id { get; set; }
    }
}
