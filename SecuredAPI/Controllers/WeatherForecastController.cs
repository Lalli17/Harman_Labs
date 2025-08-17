using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecuredAPI.Model.Data;
using SecuredAPI.Model.DTO;
using SecuredAPI.Model.Entities;

namespace SecuredAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private AppDbContext db = null;
        private TokenService tokenService = null;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext db, TokenService tokenService)
        {
            _logger = logger;
            this.db = db;
            this.tokenService = tokenService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //[Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // post .../weatherforecast/register
        [HttpPost("register")] // keep this endpoint in separate controller
        [AllowAnonymous]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid User Data");
            }
            // validate for duplicate user registration
            // dont store plain password in db. encrypt and store

            db.AppUsers.Add(user);
            db.SaveChanges();

            return Ok(); // return created
        }

        // post .../weatherforecast/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            // Verify the credentials

            if (!db.AppUsers.Any(u => u.EmailId.Equals(loginDto.LoginId) && u.Password.Equals(loginDto.Password))) // && loginDto.Role.Equals(loginDto.Role)))
            {
                return BadRequest("Invalid Credentials");
            }

            // generate JWT token
            string jwtToken = tokenService.CreateToken(loginDto);

            return Ok(jwtToken);
        }


        [HttpGet("anonymous")]
        public IActionResult UnSecuredEndpoint()
        {
            return Ok("This is for anonymous users users only");
        }

        [HttpGet("user")]
        [Authorize]
        public IActionResult Secured2Endpoint()
        {
            return Ok("This is for registered users only");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "admin")]
        public IActionResult Secured3Endpoint()
        {
            return Ok("This is for admin users only");
        }
    }
}
