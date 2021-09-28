using CarRepairService.DataBase;
using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRepairService.Repositories.Implementations
{
    public class SQLRepository<T> : ControllerBase, IRepository<T> where T : BaseModel
    {
        private readonly CRSContext db;

        public SQLRepository(CRSContext  context)
        {
            db = context;
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<ActionResult<T>> Get(int id)
        {
            T item = await db.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        public async Task<ActionResult<T>> Create(T item)
        {
            if (item == null)
                return BadRequest();
            db.Set<T>().Add(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }

        public async Task<ActionResult<T>> Update(T item)
        {
            if (item == null)
                return BadRequest();
            if (db.Set<T>().Any(x => x.Id == item.Id) == false)
                return NotFound();
            db.Update(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }

        public async Task<ActionResult<T>> Delete(int id)
        {
            T? item = db.Set<T>().FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            db.Set<T>().Remove(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }

        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
