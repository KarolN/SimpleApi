using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.Username == "PgsUser" && loginDto.Password == "TajneJakNieWiem")
            {
                return Ok("BardzoTajnyToken!@#$122342TakTokenNiePowinienBycGenerowany");
            }
            return StatusCode(401);
        }
    }
}
