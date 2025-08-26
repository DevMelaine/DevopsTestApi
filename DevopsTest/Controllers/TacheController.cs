using DevopsTest.Models;
using DevopsTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevopsTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TachesController(TacheService service) : ControllerBase
    {
        private readonly TacheService _service = service;

        [HttpGet]
        public ActionResult<List<Tache>> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Tache> Get(int id)
        {
            var tache = _service.Get(id);
            if (tache == null) return NotFound();
            return tache;
        }

        [HttpPost]
        public ActionResult<Tache> Create(Tache tache)
        {
            var created = _service.Add(tache);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
    }
}
