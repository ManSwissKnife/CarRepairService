using CarRepairService.DataBase;
using CarRepairService.Mappers;
using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRepairService.Repositories.Implementations
{
    public class SQLRepository<T> : ControllerBase, IRepository<T> where T : BaseModel
    {
        private readonly CRSContext db;
        private readonly IMapper<T> mapper;

        public SQLRepository(CRSContext  context, IMapper<T> modelMapper)
        {
            db = context;
            mapper = modelMapper;
        }

        public IEnumerable<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public ActionResult<T> Get(int id)
        {
            T? item = db.Set<T>().FirstOrDefault(m => m.Id == id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        public ActionResult<T> Create(T item)
        {
            if (item == null)
                return BadRequest();
            db.Set<T>().Add(item);
            db.SaveChanges();
            return Ok(item);
        }

        //patch
        public ActionResult<T> Update(T item)
        {
            if (item == null)
                return BadRequest();
            if (!db.Set<T>().Any(x => x.Id == item.Id))
                return NotFound();
            T? dbworker = db.Set<T>().FirstOrDefault(x => x.Id == item.Id);
            if (dbworker == null)
                return BadRequest();
            mapper.Map(item, dbworker);
            db.Update(dbworker);
            db.SaveChanges();
            return Ok(item);
        }
        //маппер

        public ActionResult<T> Delete(int id)
        {
            T? item = db.Set<T>().FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();
            db.Set<T>().Remove(item);
            db.SaveChanges();
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
