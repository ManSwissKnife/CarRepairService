using CarRepairService.PatchRequestContractResolver;

namespace CarRepairService.Models.Base
{
    public class BaseModel : PatchDtoBase
    {
        public int Id { get; set; }
    }
}
