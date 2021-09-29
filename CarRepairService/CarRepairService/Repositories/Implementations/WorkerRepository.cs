using CarRepairService.DataBase;
using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRepairService.Repositories.Implementations
{
    public class WorkerRepository : ControllerBase, IRepository<Worker>
    {
        private readonly CRSContext db;

        public WorkerRepository(CRSContext context)
        {
            db = context;
        }

        public IEnumerable<Worker> GetList()
        {
            return db.Set<Worker>().ToList();
        }

        public ActionResult<Worker> Get(int id)
        {
            Worker? item = db.Set<Worker>().FirstOrDefault(m => m.Id == id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        public ActionResult<Worker> Create(Worker item)
        {
            if (item == null)
                return BadRequest();
            db.Set<Worker>().Add(item);
            db.SaveChanges();
            return Ok(item);
        }

        //patch
        public ActionResult<Worker> Update(Worker item)
        {
            if (item == null)
                return BadRequest();
            if (!db.Set<Worker>().Any(x => x.Id == item.Id))
                return NotFound();
            var dbworker = db.Workers.FirstOrDefault(x => x.Id == item.Id);
            db.Entry(db.Workers).CurrentValues.SetValues(item);
            db.SaveChanges();
            return Ok(item);
        }
        //маппер

        public ActionResult<Worker> Delete(int id)
        {
            Worker? item = db.Set<Worker>().FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();
            db.Set<Worker>().Remove(item);
            db.SaveChanges();
            return Ok(item);
        }
    }
}
