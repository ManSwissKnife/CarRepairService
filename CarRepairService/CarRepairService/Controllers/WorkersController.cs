using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IRepository<Worker> workers;
        public WorkersController(IRepository<Worker> worker)
        {
            workers = worker;
            if (!workers.GetList().Any())
            {
                workers.Create(new Worker { Name = "Долгова Ульяна Артёмовна", Telephone = "206-02-09" });
                workers.Create(new Worker { Name = "Сергеев Сергей Маркович", Telephone = "598-75-95" });
            }
        }

        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return workers.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Worker> Get(int id)
        {
            return workers.Get(id);
        }

        [HttpPost]
        public ActionResult<Worker> Post(Worker worker)
        {
            return workers.Create(worker);
        }

        [HttpPut]
        public ActionResult<Worker> Put(Worker worker)
        {
            return workers.Update(worker);
        }

        [HttpDelete("{id}")]
        public ActionResult<Worker> Delete(int id)
        {
            return workers.Delete(id);
        }
    }
}
