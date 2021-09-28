using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IRepository<Document> Documents;
        public DocumentsController(IRepository<Document> document)
        {
            Documents = document;
        }

        [HttpGet]
        public async Task<IEnumerable<Document>> Get()
        {
            return await Documents.GetList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> Get(int id)
        {
            return await Documents.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Document>> Post(Document document)
        {
            return await Documents.Create(document);
        }

        [HttpPut]
        public async Task<ActionResult<Document>> Put(Document document)
        {
            return await Documents.Update(document);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Document>> Delete(int id)
        {
            return await Documents.Delete(id);
        }
    }
}
