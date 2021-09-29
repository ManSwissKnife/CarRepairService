namespace CarRepairService.Mappers
{
    public interface IMapper<T>
    {
        void Map(T fromEntity, T toEntity);
    }
}
