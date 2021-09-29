using CarRepairService.Models;

namespace CarRepairService.Mappers
{
    public class DocumentMapper : IMapper<Document>
    {
        public void Map(Document fromEntity, Document toEntity)
        {
            //toEntity.Telephone = fromEntity.Telephone;
            //toEntity.Name = fromEntity.Name;
        }
    }
}
