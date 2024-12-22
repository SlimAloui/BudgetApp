using BudgetAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ActifController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ActifController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Actif
    [HttpGet]
    public ActionResult<IEnumerable<Actif>> GetActifs()
    {
        return _context.Actifs.ToList();
    }

    // GET: api/Actif/5
    [HttpGet("{id}")]
    public ActionResult<Actif> GetActif(int id)
    {
        var actif = _context.Actifs.Find(id);

        if (actif == null)
        {
            return NotFound();
        }

        return actif; 
    }

    // POST: api/Actif
    [HttpPost]
    public ActionResult<Actif> PostActif(Actif actif)
    {        
        if (actif == null)
        {
            return BadRequest("Actif is null.");
        }

        if (!_context.Comptes.Any(c => c.CompteId == actif.CompteId))
        {
            return BadRequest("Invalid CompteId.");
        }
    
        _context.Actifs.Add(actif);
        _context.SaveChanges();

        return CreatedAtAction("GetActif", new { id = actif.ActifId }, actif);
    }

    // PUT: api/Actif/5
    [HttpPut("{id}")]
    public IActionResult PutActif(int id, Actif actif)
    {
        if (id != actif.ActifId)
        {
            return BadRequest();
        }

        _context.Entry(actif).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Actif/5
    [HttpDelete("{id}")]
    public ActionResult<Actif> DeleteActif(int id)
    {
        var actif = _context.Actifs.Find(id);
        if (actif == null)
        {
            return NotFound();
        }

        _context.Actifs.Remove(actif);
        _context.SaveChanges();

        return actif;
    }
}
