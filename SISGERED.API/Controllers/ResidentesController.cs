using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;


namespace SISGERED.API.Controllers

{
    [ApiController]
    [Route("/api/residentes")]
    public class ResidentesController: ControllerBase
    {
        private readonly DataContext _context;

        public ResidentesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Residentes.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var residente = await _context.Residentes.FirstOrDefaultAsync(x => x.Id == id);
            if (residente == null)
            {
                return NotFound();
            }
            return Ok(residente);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Residente residente)
        {
            _context.Add(residente);
            await _context.SaveChangesAsync();
            return Ok(residente);

        }

        [HttpPut]
        public async Task<ActionResult> Put(Residente residente)
        {
            _context.Update(residente);
            await _context.SaveChangesAsync();
            return Ok(residente);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var residente = await _context.Residentes.FirstOrDefaultAsync(x => x.Id == id);
            if (residente == null)
            {
                return NotFound();
            }

            _context.Remove(residente);
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }
}
