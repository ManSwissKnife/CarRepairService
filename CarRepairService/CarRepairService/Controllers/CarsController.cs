using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepository<Car> Cars;
        public CarsController(IRepository<Car> car)
        {
            Cars = car;
            if (Cars.GetList().Result.Count() == 0)
            {
                db.Users.Add(new User { Name = "Tom", Age = 26 });
                db.Users.Add(new User { Name = "Alice", Age = 31 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> Get()
        {
            return await Cars.GetList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return await Cars.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            return await Cars.Create(car);
        }

        [HttpPut]
        public async Task<ActionResult<Car>> Put(Car car)
        {
            return await Cars.Update(car);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            return await Cars.Delete(id);
        }
    }
}
