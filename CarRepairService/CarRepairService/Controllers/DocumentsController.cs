using CarRepairService.Models;
using CarRepairService.Repositories.Interfaces;
using CarRepairService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairService.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        ////private readonly IRepository<Document, DocumentDTO> _documents;
        //private readonly IRepairService _repairService;
        //public DocumentsController(IRepository<Document> Documents, IRepairService RepairService)
        //{
        //    _documents = Documents;
        //    _repairService = RepairService;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<Document>> Get()
        //{
        //    return await _documents.GetListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Document>> Get(int id)
        //{
        //    Document document = await _documents.GetAsync(id);
        //    if (document == null)
        //        return NotFound();
        //    return new ObjectResult(document);
        //}

        //[HttpPost]
        //public ActionResult<Document> Post(Document document)
        //{
        //    if (document == null)
        //        return BadRequest();
        //    _documents.CreateAsync(document);
        //    return Ok(document);
        //}

        //[HttpPatch]
        //public async Task<ActionResult<Document>> Patch(Document document)
        //{
        //    if (document == null)
        //        return BadRequest();
        //    Document updateDocument = await _documents.UpdateAsync(document);
        //    if (updateDocument == null)
        //        return NotFound();
        //    return Ok(updateDocument);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Document>> Delete(int id)
        //{
        //    Document document = await _documents.DeleteAsync(id);
        //    if (document == null)
        //        return NotFound();
        //    return Ok(document);
        //}
    }
}
