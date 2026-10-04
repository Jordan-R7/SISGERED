using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/reportes")]
    public class ReportesController : ControllerBase
    {
        private readonly DataContext _context;

        public ReportesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Reportes.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var Reportes = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);
            if (Reportes == null)
            {
                return NotFound();
            }
            return Ok(Reportes);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Reporte reportes)
        {
            _context.Add(reportes);
            await _context.SaveChangesAsync();
            return Ok(reportes);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Reporte reportes)
        {
            _context.Update(reportes);
            await _context.SaveChangesAsync();
            return Ok(reportes);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Reportes = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);
            if (Reportes == null)
            {
                return NotFound();
            }

            _context.Remove(Reportes);
            await _context.SaveChangesAsync();
            return NoContent();


        }
    }
}
