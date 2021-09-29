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
            if (!Cars.GetList().Any())
            {
                Cars.Create(new Car { Name = "Bentley", Number = "BM7105AX" });
                Cars.Create(new Car { Name = "BMW", Number = "BM3559AA" });
            }
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Cars.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            return Cars.Get(id);
        }

        [HttpPost]
        public ActionResult<Car> Post(Car car)
        {
            return Cars.Create(car);
        }

        [HttpPut]
        public ActionResult<Car> Put(Car car)
        {
            return Cars.Update(car);
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            return Cars.Delete(id);
        }
    }
}
