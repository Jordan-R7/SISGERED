using Microsoft.AspNetCore.Mvc;
using SISGERED.API.Data;
using Microsoft.EntityFrameworkCore;
using SISGERED.shared.Entities;

namespace SISGERED.API.Controllers;

[ApiController]
[Route("api/reportes")]
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
        var reporte = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);
        if (reporte == null)
        {
            return NotFound();
        }
        return Ok(reporte);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Reporte reporte)
    { 
        _context.Add(reporte);
        await _context.SaveChangesAsync();
        return Ok(reporte);
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
        var reportes = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);
        if (reportes == null)
        {
            return NotFound();
        }

        _context.Remove(reportes);
        await _context.SaveChangesAsync();
        return NoContent();

    }


}
