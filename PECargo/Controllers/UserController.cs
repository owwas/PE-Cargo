using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PECargo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppContext _context;

        public UserController(
            AppContext context)
        {
            this._context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return BadRequest("Does not exists.");
            }

            return Ok();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = await _context.Users.AnyAsync(x => x.Email == signUpDto.Email && x.Password == signUpDto.Password);

            if (user)
            {
                return BadRequest("Already exists.");
            }

            await _context.Users.AddAsync(
                new Data.Entities.User
                {
                    Name = signUpDto.Name,
                    Email = signUpDto.Email,
                    Password= signUpDto.Password
                });

            var result = await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class SignUpDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
