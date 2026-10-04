using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/intervenciones")]
    public class IntervencionesController : ControllerBase
    {
        private readonly DataContext _context;
        public IntervencionesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Intervenciones.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var intervension = await _context.Intervenciones.FirstOrDefaultAsync(x => x.Id == id);
            if (intervension == null)
            {
                return NotFound();
            }
            return Ok(intervension);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Intervencion intervencion)
        {
            _context.Add(intervencion);
            await _context.SaveChangesAsync();
            return Ok(intervencion);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Intervencion intervencion)
        {
            _context.Update(intervencion);
            await _context.SaveChangesAsync();
            return Ok(intervencion);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var intervencion = await _context.Intervenciones.FirstOrDefaultAsync(x => x.Id == id);
            if (intervencion == null)
            {
                return NotFound();
            }

            _context.Remove(intervencion);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}


