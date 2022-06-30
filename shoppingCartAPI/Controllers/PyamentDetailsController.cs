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
    public class PyamentDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public PyamentDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PyamentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<payment_details>>> Getpayment_Details()
        {
          if (_context.payment_Details == null)
          {
              return NotFound();
          }
            return await _context.payment_Details.ToListAsync();
        }

        // GET: api/PyamentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<payment_details>> Getpayment_details(int id)
        {
          if (_context.payment_Details == null)
          {
              return NotFound();
          }
            var payment_details = await _context.payment_Details.FindAsync(id);

            if (payment_details == null)
            {
                return NotFound();
            }

            return payment_details;
        }

        // PUT: api/PyamentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpayment_details(int id, payment_details payment_details)
        {
            if (id != payment_details.id)
            {
                return BadRequest();
            }

            _context.Entry(payment_details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payment_detailsExists(id))
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

        // POST: api/PyamentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<payment_details>> Postpayment_details(payment_details payment_details)
        {
          if (_context.payment_Details == null)
          {
              return Problem("Entity set 'DataContext.payment_Details'  is null.");
          }
            _context.payment_Details.Add(payment_details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpayment_details", new { id = payment_details.id }, payment_details);
        }

        // DELETE: api/PyamentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepayment_details(int id)
        {
            if (_context.payment_Details == null)
            {
                return NotFound();
            }
            var payment_details = await _context.payment_Details.FindAsync(id);
            if (payment_details == null)
            {
                return NotFound();
            }

            _context.payment_Details.Remove(payment_details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool payment_detailsExists(int id)
        {
            return (_context.payment_Details?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
