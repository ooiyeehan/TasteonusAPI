using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasteonusAPI.Models;
using TasteonusAPI.Data;

namespace TasteonusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly BackendDBContext _context;

        public RecipesController(BackendDBContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/Recipes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var Recipe = await _context.Recipes.FindAsync(id);

            if (Recipe == null)
            {
                return NotFound();
            }

            return Recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe Recipe)
        {
            if (id != Recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
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

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe Recipe)
        {
            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = Recipe.Id }, Recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var Recipe = await _context.Recipes.FindAsync(id);
            if (Recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(Recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }

        //[HttpGet("{category}")]
        //public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesbyCategory(string category)
        //{
        //    switch (category.ToLower())
        //    {
        //        case "all":
        //            return await _context.Recipes.ToListAsync();
        //        case "mystery":
        //            return await _context.Recipes.Where(e => e.Category == "mystery").ToListAsync();
        //        case "thriller":
        //            return await _context.Recipes.Where(e => e.Category == "thriller").ToListAsync();
        //        case "horror":
        //            return await _context.Recipes.Where(e => e.Category == "horror").ToListAsync();
        //        case "romance":
        //            return await _context.Recipes.Where(e => e.Category == "romance").ToListAsync();
        //        case "western":
        //            return await _context.Recipes.Where(e => e.Category == "western").ToListAsync();
        //        case "sci-fi":
        //            return await _context.Recipes.Where(e => e.Category == "sci-fi").ToListAsync();
        //        default:
        //            return await _context.Recipes.ToListAsync();
        //    }
        //}

        //[HttpGet("User")]
        //public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesbyUserId([FromQuery] string userid)
        //{
        //    var Recipe = await _context.Recipes.Where(e => e.UserId == userid).ToListAsync();
            
        //    if (Recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    return Recipe;
        //}

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesbySearch([FromQuery] string title)
        {
            var Recipe = await _context.Recipes.Where(e => e.Name.ToLower().Contains(title.Trim().ToLower())).ToListAsync();

            if (Recipe == null)
            {
                return NotFound();
            }

            return Recipe;
        }



    }
}
