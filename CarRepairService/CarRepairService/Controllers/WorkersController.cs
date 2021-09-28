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
        }

        [HttpGet]
        public async Task<IEnumerable<Worker>> Get()
        {
            return await Workers.GetList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> Get(int id)
        {
            return await Workers.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Worker>> Post(Worker worker)
        {
            return await Workers.Create(worker);
        }

        [HttpPut]
        public async Task<ActionResult<Worker>> Put(Worker worker)
        {
            return await Workers.Update(worker);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> Delete(int id)
        {
            return await Workers.Delete(id);
        }
    }
}
