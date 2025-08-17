using Authentication_Lab_ASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("anonymous")]
        public IActionResult AnonymousAccess() => Ok("Hello Anonymous!");

        [Authorize]
        [HttpGet("user")]
        public IActionResult AuthenticatedUser() => Ok("Hello Authenticated User!"); 

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminOnly() => Ok("Hello Admin!");
    }
