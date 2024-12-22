using BudgetAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UtilisateurController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UtilisateurController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Utilisateur
    [HttpGet]
    public ActionResult<IEnumerable<Utilisateur>> GetUtilisateurs()
    {
        return _context.Utilisateurs.ToList();
    }

    // GET: api/Utilisateur/5
    [HttpGet("{id}")]
    public ActionResult<Utilisateur> GetUtilisateur(int id)
    {
        var utilisateur = _context.Utilisateurs.Find(id);

        if (utilisateur == null)
        {
            return NotFound();
        }

        return utilisateur;
    }

    // POST: api/Utilisateur
    [HttpPost]
    public ActionResult<Utilisateur> PostUtilisateur(Utilisateur utilisateur)
    {
        _context.Utilisateurs.Add(utilisateur);
        _context.SaveChanges();

        return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UtilisateurId }, utilisateur);
    }

    // PUT: api/Utilisateur/5
    [HttpPut("{id}")]
    public IActionResult PutUtilisateur(int id, Utilisateur utilisateur)
    {
        if (id != utilisateur.UtilisateurId)
        {
            return BadRequest();
        }

        _context.Entry(utilisateur).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Utilisateur/5
    [HttpDelete("{id}")]
    public ActionResult<Utilisateur> DeleteUtilisateur(int id)
    {
        var utilisateur = _context.Utilisateurs.Find(id);
        if (utilisateur == null)
        {
            return NotFound();
        }

        _context.Utilisateurs.Remove(utilisateur);
        _context.SaveChanges();

        return utilisateur;
    }
}
