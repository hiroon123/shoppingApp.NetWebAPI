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
    public class OrderItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<order_items>>> GetOrder_Items()
        {
          if (_context.Order_Items == null)
          {
              return NotFound();
          }
            return await _context.Order_Items.ToListAsync();
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<order_items>> Getorder_items(int id)
        {
          if (_context.Order_Items == null)
          {
              return NotFound();
          }
            var order_items = await _context.Order_Items.FindAsync(id);

            if (order_items == null)
            {
                return NotFound();
            }

            return order_items;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putorder_items(int id, order_items order_items)
        {
            if (id != order_items.id)
            {
                return BadRequest();
            }

            _context.Entry(order_items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!order_itemsExists(id))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<order_items>> Postorder_items(order_items order_items)
        {
          if (_context.Order_Items == null)
          {
              return Problem("Entity set 'DataContext.Order_Items'  is null.");
          }
            _context.Order_Items.Add(order_items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getorder_items", new { id = order_items.id }, order_items);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorder_items(int id)
        {
            if (_context.Order_Items == null)
            {
                return NotFound();
            }
            var order_items = await _context.Order_Items.FindAsync(id);
            if (order_items == null)
            {
                return NotFound();
            }

            _context.Order_Items.Remove(order_items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool order_itemsExists(int id)
        {
            return (_context.Order_Items?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
