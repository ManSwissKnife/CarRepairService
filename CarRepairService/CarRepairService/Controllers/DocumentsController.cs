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
        public IEnumerable<Document> Get()
        {
            return Documents.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Document> Get(int id)
        {
            return Documents.Get(id);
        }

        [HttpPost]
        public ActionResult<Document> Post(Document document)
        {
            return Documents.Create(document);
        }

        [HttpPut]
        public ActionResult<Document> Put(Document document)
        {
            return Documents.Update(document);
        }

        [HttpDelete("{id}")]
        public ActionResult<Document> Delete(int id)
        {
            return Documents.Delete(id);
        }
    }
}
