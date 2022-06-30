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
    public class AccessLevelController : ControllerBase
    {
        private readonly DataContext _context;

        public AccessLevelController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccessLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<access_level>>> GetAccess_Levels()
        {
          if (_context.Access_Levels == null)
          {
              return NotFound();
          }
            return await _context.Access_Levels.ToListAsync();
        }

        // GET: api/AccessLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<access_level>> Getaccess_level(int id)
        {
          if (_context.Access_Levels == null)
          {
              return NotFound();
          }
            var access_level = await _context.Access_Levels.FindAsync(id);

            if (access_level == null)
            {
                return NotFound();
            }

            return access_level;
        }

        // PUT: api/AccessLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaccess_level(int id, access_level access_level)
        {
            if (id != access_level.id)
            {
                return BadRequest();
            }

            _context.Entry(access_level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!access_levelExists(id))
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

        // POST: api/AccessLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<access_level>> Postaccess_level(access_level access_level)
        {
          if (_context.Access_Levels == null)
          {
              return Problem("Entity set 'DataContext.Access_Levels'  is null.");
          }
            _context.Access_Levels.Add(access_level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaccess_level", new { id = access_level.id }, access_level);
        }

        // DELETE: api/AccessLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteaccess_level(int id)
        {
            if (_context.Access_Levels == null)
            {
                return NotFound();
            }
            var access_level = await _context.Access_Levels.FindAsync(id);
            if (access_level == null)
            {
                return NotFound();
            }

            _context.Access_Levels.Remove(access_level);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool access_levelExists(int id)
        {
            return (_context.Access_Levels?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
