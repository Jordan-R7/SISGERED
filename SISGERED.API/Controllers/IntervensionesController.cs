using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/intervensiones")]
    public class IntervensionesController : ControllerBase
    {
        private readonly DataContext _context;
        public IntervensionesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Intervensiones.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var intervension = await _context.Intervensiones.FirstOrDefaultAsync(x => x.Id == id);
            if (intervension == null)
            {
                return NotFound();
            }
            return Ok(intervension);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Intervension intervension)
        {
            _context.Add(intervension);
            await _context.SaveChangesAsync();
            return Ok(intervension);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Intervension intervension)
        {
            _context.Update(intervension);
            await _context.SaveChangesAsync();
            return Ok(intervension);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var intervension = await _context.Intervensiones.FirstOrDefaultAsync(x => x.Id == id);
            if (intervension == null)
            {
                return NotFound();
            }

            _context.Remove(intervension);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}


