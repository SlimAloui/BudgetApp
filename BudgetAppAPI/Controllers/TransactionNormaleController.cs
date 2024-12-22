using BudgetAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TransactionNormaleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TransactionNormaleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/TransactionNormale
    [HttpGet]
    public ActionResult<IEnumerable<TransactionNormale>> GetTransactionsNormales()
    {
        return _context.TransactionsNormales.ToList();
    }

    // GET: api/TransactionNormale/5
    [HttpGet("{id}")]
    public ActionResult<TransactionNormale> GetTransactionNormale(int id)
    {
        var transaction = _context.TransactionsNormales.Find(id);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

    // POST: api/TransactionNormale
    [HttpPost]
    public ActionResult<TransactionNormale> PostTransactionNormale(TransactionNormale transaction)
    {
        _context.TransactionsNormales.Add(transaction);
        _context.SaveChanges();

        return CreatedAtAction("GetTransactionNormale", new { id = transaction.TransactionId }, transaction);
    }

    // PUT: api/TransactionNormale/5
    [HttpPut("{id}")]
    public IActionResult PutTransactionNormale(int id, TransactionNormale transaction)
    {
        if (id != transaction.TransactionId)
        {
            return BadRequest();
        }

        _context.Entry(transaction).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/TransactionNormale/5
    [HttpDelete("{id}")]
    public ActionResult<TransactionNormale> DeleteTransactionNormale(int id)
    {
        var transaction = _context.TransactionsNormales.Find(id);
        if (transaction == null)
        {
            return NotFound();
        }

        _context.TransactionsNormales.Remove(transaction);
        _context.SaveChanges();

        return transaction;
    }
}
