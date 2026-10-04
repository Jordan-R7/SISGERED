using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/revisiones")]
    public class RevisionesController : ControllerBase
    {
        private readonly DataContext _context;

        public RevisionesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Revisiones.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var Revisiones = await _context.Revisiones.FirstOrDefaultAsync(x => x.Id == id);
            if (Revisiones == null)
            {
                return NotFound();
            }
            return Ok(Revisiones);
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
            var Revisiones = await _context.Revisiones.FirstOrDefaultAsync(x => x.Id == id);
            if (Revisiones == null)
            {
                return NotFound();
            }

            _context.Remove(Revisiones);
            await _context.SaveChangesAsync();
            return NoContent();


        }
    }
}