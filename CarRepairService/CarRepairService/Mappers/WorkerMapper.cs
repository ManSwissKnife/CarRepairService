using CarRepairService.Models;

namespace CarRepairService.Mappers
{
    public class WorkerMapper : IMapper<Worker>
    {
        public void Map(Worker fromEntity, Worker toEntity)
        {
            toEntity.Telephone = fromEntity.Telephone;
            toEntity.Name = fromEntity.Name;
        }
    }
}
