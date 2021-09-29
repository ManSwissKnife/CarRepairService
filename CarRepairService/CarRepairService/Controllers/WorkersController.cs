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
        private readonly IRepository<Worker> Workers;
        public WorkersController(IRepository<Worker> worker)
        {
            Workers = worker;
            if (!Workers.GetList().Any())
            {
                Workers.Create(new Worker { Name = "Долгова Ульяна Артёмовна", Telephone = "206-02-09" });
                Workers.Create(new Worker { Name = "Сергеев Сергей Маркович", Telephone = "598-75-95" });
            }
        }

        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return Workers.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Worker> Get(int id)
        {
            return Workers.Get(id);
        }

        [HttpPost]
        public ActionResult<Worker> Post(Worker worker)
        {
            return Workers.Create(worker);
        }

        [HttpPut]
        public ActionResult<Worker> Put(Worker worker)
        {
            return Workers.Update(worker);
        }

        [HttpDelete("{id}")]
        public ActionResult<Worker> Delete(int id)
        {
            return Workers.Delete(id);
        }
    }
}
