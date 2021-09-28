using CarRepairService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Repositories.Interfaces
{
    public interface IRepository<T> /*: IDisposable*/ where T : BaseModel
    {
        Task<IEnumerable<T>> GetList(); // получение всех объектов
        Task<ActionResult<T>> Get(int id);
        Task<ActionResult<T>> Create(T item);
        Task<ActionResult<T>> Update(T item);
        Task<ActionResult<T>> Delete(int id);
        //void Save();  // сохранение изменений
    }
}
