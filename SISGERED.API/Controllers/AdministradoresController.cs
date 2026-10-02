using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers
{
    
    [ApiController]
    [Route("/api/administradores")]
    public class AdministradoresController:ControllerBase
    {
        private readonly DataContext _context;
        public AdministradoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
         public async Task<ActionResult> GetAsync()
        { 
            return Ok(await _context.Administradores.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var administrador = await _context.Administradores.FirstOrDefaultAsync(x => x.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }
            return Ok(administrador);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Administrador administrador)
        {
            _context.Add(administrador);
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Administrador administrador)
        {
            _context.Update(administrador);
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var administrador = await _context.Administradores.FirstOrDefaultAsync(x => x.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Remove(administrador);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}
