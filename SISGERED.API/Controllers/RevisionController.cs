using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/revision")]
    public class RevisionController : ControllerBase
    {
        private readonly DataContext _context;
        public RevisionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Ubicaciones.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var ubicacion = await _context.Ubicaciones.FirstOrDefaultAsync(x => x.Id == id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            return Ok(ubicacion);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Revision revision)
        {
            _context.Add(revision);
            await _context.SaveChangesAsync();
            return Ok(revision);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Revision revision)
        {
            _context.Update(revision);
            await _context.SaveChangesAsync();
            return Ok(revision);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var revision = await _context.Revisiones.FirstOrDefaultAsync(x => x.Id == id);
            if (revision == null)
            {
                return NotFound();
            }

            _context.Remove(revision);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}