using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/ubicaciones")]
    public class UbicacionesController : ControllerBase
    {
        private readonly DataContext _context;

        public UbicacionesController(DataContext context)
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
        public async Task<ActionResult> Post(Ubicacion ubicacion)
        {
            _context.Add(ubicacion);
            await _context.SaveChangesAsync();
            return Ok(ubicacion);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ubicacion ubicacion)
        {
            _context.Update(ubicacion);
            await _context.SaveChangesAsync();
            return Ok(ubicacion);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ubicacion = await _context.Ubicaciones.FirstOrDefaultAsync(x => x.Id == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Remove(ubicacion);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
