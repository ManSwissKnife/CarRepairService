using CarRepairService.Models;
using CarRepairService.Models.DTO;
using CarRepairService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product, ProductDTO> _products;
        public ProductsController(IRepository<Product, ProductDTO> products)
        {
            _products = products;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _products.GetListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _products.GetAsync(id);
            if (product == null)
                return NotFound();
            return new ObjectResult(product);
        }

        [Authorize]
        [HttpPost("{id}/buy")]
        public async Task<ActionResult<Product>> Buy(int id)
        {
            Product product = await _products.GetAsync(id);
            if (product == null)
                return NotFound();
            return new ObjectResult(product);
        }

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if (product == null)
                return BadRequest();
            _products.CreateAsync(product);
            return Ok(product);
        }

        [HttpPatch]
        public async Task<ActionResult<Product>> Patch(ProductDTO product)
        {
            if (product == null)
                return BadRequest();
            Product updateProduct = await _products.UpdateAsync(product);
            if (updateProduct == null)
                return NotFound();
            return Ok(updateProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            Product product = await _products.DeleteAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
