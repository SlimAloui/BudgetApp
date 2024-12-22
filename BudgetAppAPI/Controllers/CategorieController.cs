using BudgetAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CategorieController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategorieController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Categorie
    [HttpGet]
    public ActionResult<IEnumerable<Categorie>> GetCategories()
    {
        return _context.Categories.ToList();
    }

    // GET: api/Categorie/5
    [HttpGet("{id}")]
    public ActionResult<Categorie> GetCategorie(int id)
    {
        var categorie = _context.Categories.Find(id);

        if (categorie == null)
        {
            return NotFound();
        }

        return categorie;
    }

    // POST: api/Categorie
    [HttpPost]
    public ActionResult<Categorie> PostCategorie(Categorie categorie)
    {
        _context.Categories.Add(categorie);
        _context.SaveChanges();

        return CreatedAtAction("GetCategorie", new { id = categorie.CategorieId }, categorie);
    }

    // PUT: api/Categorie/5
    [HttpPut("{id}")]
    public IActionResult PutCategorie(int id, Categorie categorie)
    {
        if (id != categorie.CategorieId)
        {
            return BadRequest();
        }

        _context.Entry(categorie).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Categorie/5
    [HttpDelete("{id}")]
    public ActionResult<Categorie> DeleteCategorie(int id)
    {
        var categorie = _context.Categories.Find(id);
        if (categorie == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(categorie);
        _context.SaveChanges();

        return categorie;
    }
}
