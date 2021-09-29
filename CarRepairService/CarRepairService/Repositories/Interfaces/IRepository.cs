using CarRepairService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Repositories.Interfaces
{
    public interface IRepository<T> /*: IDisposable*/ where T : BaseModel
    {
        IEnumerable<T> GetList();
        ActionResult<T> Get(int id);
        ActionResult<T> Create(T item);
        ActionResult<T> Update(T item);
        ActionResult<T> Delete(int id);
        //void Save();
    }
}
