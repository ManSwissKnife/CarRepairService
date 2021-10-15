using CarRepairService.Models.Base;

namespace CarRepairService.Repositories.Interfaces
{
    public interface IRepository<T, Y> /*: IDisposable*/ where T : BaseModel where Y : BaseModel
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(Y item);
        Task<T> DeleteAsync(int id);
    }
}
