using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Indulgence.Models;
using System.Linq;
using System;

namespace Indulgence.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CocktailController : ControllerBase
  {
    private readonly IndulgenceContext _db;

    public CocktailController(IndulgenceContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cocktail>>> Get(Ingredient ingredienttype)
    {
      var query = _db.Cocktails.AsQueryable();

      if (ingredienttype != null)
      {
        query = query.Where(entry => entry.Ingredients.Contains(ingredienttype));
      }

      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Cocktail>> Post(Cocktail cocktail)
    {
      _db.Cocktails.Add(cocktail);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCocktail), new { id = cocktail.CocktailId }, cocktail);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cocktail>> GetCocktail(int id)
    {
      var cocktail = await _db.Cocktails.FindAsync(id);

      if (cocktail == null)
      {
        return NotFound();
      }

      return cocktail;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cocktail cocktail)
    {
      if (id != cocktail.CocktailId)
      {
        return BadRequest();
      }

      _db.Entry(cocktail).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CocktailExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCocktail(int id)
    {
      var cocktail = await _db.Cocktails.FindAsync(id);
      if (cocktail == null)
      {
        return NotFound();
      }

      _db.Cocktails.Remove(cocktail);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool CocktailExists(int id)
    {
      return _db.Cocktails.Any(e => e.CocktailId == id);
    }
  }
}