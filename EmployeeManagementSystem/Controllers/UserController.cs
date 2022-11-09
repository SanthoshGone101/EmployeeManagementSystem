using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserDbContext obj = null;
        public UserController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = obj.users.AsQueryable();
            return Ok(userdetails);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(Registration p)
        {
            if(obj.users.Any(u=>u.Email==p.Email))
            {
                return BadRequest("Already Registered");
            }
            var user = new User
            {
                Email = p.Email,
                Password = p.Password
            };
            obj.users.Add(user);
            await obj.SaveChangesAsync();
            return Ok(new { statusCode = 200, message = "registered Successfully" });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(Login p)
        {
            try
            {
                var user = await obj.users.FirstOrDefaultAsync(u => u.Email == p.Email);
                if (user == null)
                {
                    return BadRequest("user not found");
                }
                if (user.Password != p.Password)
                {
                    return BadRequest("Password is incorrect");
                }
                return Ok(new { statusCode = 200, message = "login Successfull" });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
