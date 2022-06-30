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
    public class OrderDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<order_details>>> GetOrder_Details()
        {
          if (_context.Order_Details == null)
          {
              return NotFound();
          }
            return await _context.Order_Details.ToListAsync();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<order_details>> Getorder_details(int id)
        {
          if (_context.Order_Details == null)
          {
              return NotFound();
          }
            var order_details = await _context.Order_Details.FindAsync(id);

            if (order_details == null)
            {
                return NotFound();
            }

            return order_details;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putorder_details(int id, order_details order_details)
        {
            if (id != order_details.id)
            {
                return BadRequest();
            }

            _context.Entry(order_details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!order_detailsExists(id))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<order_details>> Postorder_details(order_details order_details)
        {
          if (_context.Order_Details == null)
          {
              return Problem("Entity set 'DataContext.Order_Details'  is null.");
          }
            _context.Order_Details.Add(order_details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getorder_details", new { id = order_details.id }, order_details);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorder_details(int id)
        {
            if (_context.Order_Details == null)
            {
                return NotFound();
            }
            var order_details = await _context.Order_Details.FindAsync(id);
            if (order_details == null)
            {
                return NotFound();
            }

            _context.Order_Details.Remove(order_details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool order_detailsExists(int id)
        {
            return (_context.Order_Details?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
