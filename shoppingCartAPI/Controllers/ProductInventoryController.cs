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
    public class ProductInventoryController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductInventoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductInventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<product_inventory>>> GetProduct_Inventories()
        {
          if (_context.Product_Inventories == null)
          {
              return NotFound();
          }
            return await _context.Product_Inventories.ToListAsync();
        }

        // GET: api/ProductInventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<product_inventory>> Getproduct_inventory(int id)
        {
          if (_context.Product_Inventories == null)
          {
              return NotFound();
          }
            var product_inventory = await _context.Product_Inventories.FindAsync(id);

            if (product_inventory == null)
            {
                return NotFound();
            }

            return product_inventory;
        }

        // PUT: api/ProductInventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproduct_inventory(int id, product_inventory product_inventory)
        {
            if (id != product_inventory.id)
            {
                return BadRequest();
            }

            _context.Entry(product_inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!product_inventoryExists(id))
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

        // POST: api/ProductInventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<product_inventory>> Postproduct_inventory(product_inventory product_inventory)
        {
          if (_context.Product_Inventories == null)
          {
              return Problem("Entity set 'DataContext.Product_Inventories'  is null.");
          }
            _context.Product_Inventories.Add(product_inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduct_inventory", new { id = product_inventory.id }, product_inventory);
        }

        // DELETE: api/ProductInventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduct_inventory(int id)
        {
            if (_context.Product_Inventories == null)
            {
                return NotFound();
            }
            var product_inventory = await _context.Product_Inventories.FindAsync(id);
            if (product_inventory == null)
            {
                return NotFound();
            }

            _context.Product_Inventories.Remove(product_inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool product_inventoryExists(int id)
        {
            return (_context.Product_Inventories?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
