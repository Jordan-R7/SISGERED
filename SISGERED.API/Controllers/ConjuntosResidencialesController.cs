using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;


namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/conjuntosresidenciales")]
    public class ConjuntosResidencialesController : ControllerBase
    {
        private readonly DataContext _context;

        public ConjuntosResidencialesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.ConjuntosResidenciales.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var conjuntoResidencial = await _context.ConjuntosResidenciales.FirstOrDefaultAsync(x => x.Id == id);
            if (conjuntoResidencial == null)
            {
                return NotFound();
            }
            return Ok(conjuntoResidencial);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ConjuntoResidencial conjuntoResidencial)
        {
            _context.Add(conjuntoResidencial);
            await _context.SaveChangesAsync();
            return Ok(conjuntoResidencial);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ConjuntoResidencial conjuntoresidencial)
        {
            _context.Update(conjuntoresidencial);
            await _context.SaveChangesAsync();
            return Ok(conjuntoresidencial);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var conjuntoResidencial = await _context.ConjuntosResidenciales.FirstOrDefaultAsync(x => x.Id == id);
            if (conjuntoResidencial == null)
            {
                return NotFound();
            }

             _context.Remove(conjuntoResidencial);
            await _context.SaveChangesAsync();
            return NoContent();

        }




    }
}
