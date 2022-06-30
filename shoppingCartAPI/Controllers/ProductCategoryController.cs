using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppingCartAPI;
using shoppingCartAPI.Data;

namespace shoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductCategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<product_category>>> GetProduct_Categories()
        {
          if (_context.Product_Categories == null)
          {
              return NotFound();
          }
            return await _context.Product_Categories.ToListAsync();
        }

        // GET: api/ProductCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<product_category>> Getproduct_category(int id)
        {
          if (_context.Product_Categories == null)
          {
              return NotFound();
          }
            var product_category = await _context.Product_Categories.FindAsync(id);

            if (product_category == null)
            {
                return NotFound();
            }

            return product_category;
        }

        // PUT: api/ProductCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproduct_category(int id, product_category product_category)
        {
            if (id != product_category.id)
            {
                return BadRequest();
            }

            _context.Entry(product_category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!product_categoryExists(id))
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

        // POST: api/ProductCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<product_category>> Postproduct_category(product_category product_category)
        {
          if (_context.Product_Categories == null)
          {
              return Problem("Entity set 'DataContext.Product_Categories'  is null.");
          }
            _context.Product_Categories.Add(product_category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduct_category", new { id = product_category.id }, product_category);
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduct_category(int id)
        {
            if (_context.Product_Categories == null)
            {
                return NotFound();
            }
            var product_category = await _context.Product_Categories.FindAsync(id);
            if (product_category == null)
            {
                return NotFound();
            }

            _context.Product_Categories.Remove(product_category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool product_categoryExists(int id)
        {
            return (_context.Product_Categories?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
