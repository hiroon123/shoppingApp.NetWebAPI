using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(int id, user user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/User/Register
        //api/post
        [HttpPost("Register")]
        public async Task<ActionResult> Register(user_register_request request)
        {
            if (_context.Users.Any(u => u.email == request.email))
            {
                return BadRequest("User already exists");
            }

            createPasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new user
            {
                email = request.email,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                verification_token = createToken(),
                first_name = request.first_name,
                last_name = request.last_name,
                dob = request.dob,
                gender = request.gender,
                created = DateTime.UtcNow,
                modified = DateTime.UtcNow
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok("User Created");
        }

        //Generate Password Hash and Salt
        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //Generate Random Token
        private string createToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        // POST: api/User/Login
        //api/post
        [HttpPost("Login")]
        public async Task<ActionResult> Login(user_login_request request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == request.email);

            if(user == null)
            {
                return BadRequest("User Not Found");
            }

            if(!verifyPasswordHash(request.password, user.passwordHash, user.passwordSalt))
            {
                return BadRequest("Wrong Password");
            }

            if (user.verfied_at == null)
            {
                return BadRequest("Not Verified");
            }

            return Ok("Success");
        }

        //Check Password Hash and Salt
        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedPasswordHash.SequenceEqual(passwordHash);
            }
        }


        //Verify Authentication Token
        //api/post
        [HttpPost("VerifyToken")]
        public async Task<ActionResult> VerifyToken(string email, string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email && u.verification_token == token);
            if(user == null)
            {
                return BadRequest("Invalid Token");
            }
            user.verfied_at = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok("Token Verfied");
        }


        //Forgot Password
        //api/post
        [HttpPost("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
            if(user == null)
            {
                return BadRequest("User Not Found");
            }
            user.password_reset_token = createToken(); //To-Do -> Check if this token already exists in the DB
            user.reset_token_expires = DateTime.UtcNow.AddDays(1); // Token Expires in 24hrs
            await _context.SaveChangesAsync();

            return Ok("Token Sent"); //To-Do -> Send Reset token via email
            
        }


        //Reset Password
        //api/post
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(reset_password_request request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == request.email && u.password_reset_token == request.token);
            if(user == null)
            {
                return BadRequest("Invalid Token");
            }

            createPasswordHash(request.password, out byte[] passwrodHash, out byte[] passwordSalt);
            user.passwordHash = passwrodHash;
            user.passwordSalt = passwordSalt;
            user.password_reset_token = null;
            user.reset_token_expires = null;

            await _context.SaveChangesAsync();
            return Ok("Password Resetted");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userExists(int id)
        {
            return (_context.Users?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
