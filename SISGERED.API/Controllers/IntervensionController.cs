using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISGERED.API.Data;
using SISGERED.API.entidades;
using SISGERED.shared.Entities;
namespace SISGERED.API.Controllers
{

    public class IntervesionController : ControllerBase
    {
        private readonly DataContext _context;
        public IntervesionController(DataContext context)
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
            var intervecion = await _context.Intervenciones.FirstOrDefaultAsync(x => x.Id == id);
            if (intervecion == null)
            {
                return NotFound();
            }
            return Ok(intervecion);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Intervecion intervecion)
        {
            _context.Add(intervecion);
            await _context.SaveChangesAsync();
            return Ok(intervecion);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Intervecion intervecion)
        {
            _context.Update(intervecion);
            await _context.SaveChangesAsync();
            return Ok(intervecion);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var intervecion = await _context.Intervenciones.FirstOrDefaultAsync(x => x.Id == id);
            if (intervecion == null)
            {
                return NotFound();
            }

            _context.Remove(intervecion);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}


