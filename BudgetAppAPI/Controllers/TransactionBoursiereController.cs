using BudgetAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TransactionBoursiereController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TransactionBoursiereController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/TransactionBoursiere
    [HttpGet]
    public ActionResult<IEnumerable<TransactionBoursiere>> GetTransactionsBoursieres()
    {
        return _context.TransactionsBoursieres.ToList();
    }

    // GET: api/TransactionBoursiere/5
    [HttpGet("{id}")]
    public ActionResult<TransactionBoursiere> GetTransactionBoursiere(int id)
    {
        var transaction = _context.TransactionsBoursieres.Find(id);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

    // POST: api/TransactionBoursiere
    [HttpPost]
    public ActionResult<TransactionBoursiere> PostTransactionBoursiere(TransactionBoursiere transaction)
    {
        if (transaction == null)
        {
            return BadRequest("Transaction is null.");
        }

        if (!_context.Utilisateurs.Any(u => u.UtilisateurId == transaction.UtilisateurId) ||
            !_context.Comptes.Any(c => c.CompteId == transaction.CompteId) ||
            !_context.Actifs.Any(a => a.ActifId == transaction.ActifId))
        {
            return BadRequest("Invalid foreign key.");
        }
        _context.TransactionsBoursieres.Add(transaction);
        _context.SaveChanges();

        return CreatedAtAction("GetTransactionBoursiere", new { id = transaction.TransactionId }, transaction);
    }

    // PUT: api/TransactionBoursiere/5
    [HttpPut("{id}")]
    public IActionResult PutTransactionBoursiere(int id, TransactionBoursiere transaction)
    {
        if (id != transaction.TransactionId)
        {
            return BadRequest();
        }

        _context.Entry(transaction).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/TransactionBoursiere/5
    [HttpDelete("{id}")]
    public ActionResult<TransactionBoursiere> DeleteTransactionBoursiere(int id)
    {
        var transaction = _context.TransactionsBoursieres.Find(id);
        if (transaction == null)
        {
            return NotFound();
        }

        _context.TransactionsBoursieres.Remove(transaction);
        _context.SaveChanges();

        return transaction;
    }
}
