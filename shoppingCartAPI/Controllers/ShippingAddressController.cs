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
    public class ShippingAddressController : ControllerBase
    {
        private readonly DataContext _context;

        public ShippingAddressController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ShippingAddress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<shipping_address>>> GetShipping_Addresses()
        {
          if (_context.Shipping_Addresses == null)
          {
              return NotFound();
          }
            return await _context.Shipping_Addresses.ToListAsync();
        }

        // GET: api/ShippingAddress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<shipping_address>> Getshipping_address(int id)
        {
          if (_context.Shipping_Addresses == null)
          {
              return NotFound();
          }
            var shipping_address = await _context.Shipping_Addresses.FindAsync(id);

            if (shipping_address == null)
            {
                return NotFound();
            }

            return shipping_address;
        }

        // PUT: api/ShippingAddress/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putshipping_address(int id, shipping_address shipping_address)
        {
            if (id != shipping_address.id)
            {
                return BadRequest();
            }

            _context.Entry(shipping_address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!shipping_addressExists(id))
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

        // POST: api/ShippingAddress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<shipping_address>> Postshipping_address(shipping_address shipping_address)
        {
          if (_context.Shipping_Addresses == null)
          {
              return Problem("Entity set 'DataContext.Shipping_Addresses'  is null.");
          }
            _context.Shipping_Addresses.Add(shipping_address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getshipping_address", new { id = shipping_address.id }, shipping_address);
        }

        // DELETE: api/ShippingAddress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteshipping_address(int id)
        {
            if (_context.Shipping_Addresses == null)
            {
                return NotFound();
            }
            var shipping_address = await _context.Shipping_Addresses.FindAsync(id);
            if (shipping_address == null)
            {
                return NotFound();
            }

            _context.Shipping_Addresses.Remove(shipping_address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool shipping_addressExists(int id)
        {
            return (_context.Shipping_Addresses?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
