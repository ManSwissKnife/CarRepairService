using CarRepairService.Models;

namespace CarRepairService.Mappers
{
    public class CarMapper : IMapper<Car>
    {
        public void Map(Car fromEntity, Car toEntity)
        {
            //toEntity.Telephone = fromEntity.Telephone;
            //toEntity.Name = fromEntity.Name;
        }
    }
}
