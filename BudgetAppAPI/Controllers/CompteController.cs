using BudgetAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CompteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Compte
    [HttpGet]
    public ActionResult<IEnumerable<Compte>> GetComptes()
    {
        return _context.Comptes
            .Include(c => c.Utilisateur) // Charger l'utilisateur lié
            .ToList();
    }

    // GET: api/Compte/5
    [HttpGet("{id}")]
    public ActionResult<Compte> GetCompte(int id)
    {
        var compte = _context.Comptes
            .Include(c => c.Utilisateur) // Charger l'utilisateur lié
            .FirstOrDefault(c => c.CompteId == id);

        if (compte == null)
        {
            return NotFound();
        }

        return compte;
    }

    // POST: api/Compte
    [HttpPost]
    public ActionResult<Compte> PostCompte(Compte compte)
    {
        _context.Comptes.Add(compte);
        _context.SaveChanges();

        return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
    }

    // PUT: api/Compte/5
    [HttpPut("{id}")]
    public IActionResult PutCompte(int id, Compte compte)
    {
        if (id != compte.CompteId)
        {
            return BadRequest();
        }

        _context.Entry(compte).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Compte/5
    [HttpDelete("{id}")]
    public ActionResult<Compte> DeleteCompte(int id)
    {
        var compte = _context.Comptes.Find(id);
        if (compte == null)
        {
            return NotFound();
        }

        _context.Comptes.Remove(compte);
        _context.SaveChanges();

        return compte;
    }

    // GET: api/Compte/5/solde
    [HttpGet("{id}/solde")]
    public ActionResult<decimal> GetSolde(int id)
    {
        var compte = _context.Comptes
            .Include(c => c.TransactionsNormales)
            .Include(c => c.TransactionsBoursieres)
            .FirstOrDefault(c => c.CompteId == id);

        if (compte == null)
        {
            return NotFound();
        }

        // Calculer le solde en prenant en compte les transactions
        var solde = compte.SoldeCash
                    + compte.TransactionsNormales.Where(t => t.TypeTransaction == "revenu").Sum(t => t.Montant)
                    - compte.TransactionsNormales.Where(t => t.TypeTransaction == "depense").Sum(t => t.Montant);
                    // + compte.TransactionsBoursieres.Where(t => t.TypeTransaction == "vente").Sum(t => t.Quantite * t.PrixUnitaire)
                    // - compte.TransactionsBoursieres.Where(t => t.TypeTransaction == "achat").Sum(t => t.Quantite * t.PrixUnitaire)
                    // - compte.TransactionsBoursieres.Sum(t => t.Taxe)
                    // - compte.TransactionsBoursieres.Sum(t => t.Frais);

        return solde;
    }
}
