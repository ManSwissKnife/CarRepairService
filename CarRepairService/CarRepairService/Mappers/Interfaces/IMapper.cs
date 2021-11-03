﻿namespace CarRepairService.Mappers.Interfaces
{
    public interface IMapper<T, Y>
    {
        void Map(T fromEntity, Y toEntity);
        void Map(T fromEntity, T toEntity);
    }
}
