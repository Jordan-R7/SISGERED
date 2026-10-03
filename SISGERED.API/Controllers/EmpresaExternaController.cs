using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;
namespace SISGERED.API.Controllers
{
    public class EmpresaExternaController : ControllerBase
    {
        private readonly DataContext _context;
        public EmpresaExternaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.EmpresasExternas.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var empresaexterna = await _context.EmpresasExternas.FirstOrDefaultAsync(x => x.Id == id);
            if (empresaexterna == null)
            {
                return NotFound();
            }
            return Ok(empresaexterna);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmpresaExterna empresaexterna)
        {
            _context.Add(empresaexterna);
            await _context.SaveChangesAsync();
            return Ok(empresaexterna);
        }


        [HttpPut]
        public async Task<ActionResult> Put(EmpresaExterna empresaexterna)
        {
            _context.Update(empresaexterna);
            await _context.SaveChangesAsync();
            return Ok(empresaexterna);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var empresaexterna = await _context.EmpresasExternas.FirstOrDefaultAsync(x => x.Id == id);
            if (empresaexterna == null)
            {
                return NotFound();
            }

            _context.Remove(empresaexterna);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}

