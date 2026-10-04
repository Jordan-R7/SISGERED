using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISGERED.API.Data;
using SISGERED.API.entidades;
using SISGERED.shared.Entities;
namespace SISGERED.API.Controllers
{
    [ApiController]
    [Route("/api/personal")]
    public class PersonalControllers : ControllerBase
    {
        private readonly DataContext _context;
        public PersonalControllers (DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Personal.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var personal = await _context.Personal.FirstOrDefaultAsync(x => x.Id == id);
            if (personal == null)
            {
                return NotFound();
            }
            return Ok(personal);
        }

        [HttpPost]
        public async Task<ActionResult> Post(personal personal)
        {
            _context.Add(personal);
            await _context.SaveChangesAsync();
            return Ok(personal);
        }


        [HttpPut]
        public async Task<ActionResult> Put(personal personal)
        {
            _context.Update(personal);
            await _context.SaveChangesAsync();
            return Ok(personal);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var personal = await _context.Personal.FirstOrDefaultAsync(x => x.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            _context.Remove(personal);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}

