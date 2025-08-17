using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurApi.Model.Data;
using SecurApi.Model.DTO;
using SecurApi.Model.Entities;

namespace SecurApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private AppDbContext db = null;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext db, TokenService tokenService)
        {
            this.db = db;
            _logger = logger;
            this.tokenService = tokenService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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


        //post .../WeatherForcast/register
        [HttpPost("register")] //keep this end point in seperate controller

        public IActionResult Register(User user)//seperate controller for registration and login
        {
           if (!ModelState.IsValid)
            {
                return BadRequest("Invalid user data");
            }
            //validate for duplicate user registration
            //dont store plain passwords encrypt t and store it 

            //save it 
            db.AppUsers.Add(user);
            db.SaveChanges();

            return Ok();
        }


        //post.../Weatherorcast/login
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            //verify the credentials

           if(! db.AppUsers.Any(u => u.Email.Equals(loginDto.LoginId, StringComparison.OrdinalIgnoreCase) 
            && u.Password.Equals(loginDto.Password)))
           // && loginDto.Role.Equals(loginDto.Role)))
            {
                return BadRequest("invalid credentials");
            }
            string jwtToken = tokenService.CreateToken(loginDto);           // generate JWT token

            return Ok(jwtToken);
        }





        [HttpGet("anonymous")]//pathname
        public IActionResult UnSecuredEndpoint()
        {
            return Ok("This is for anonymous in users only");
        }

        [HttpGet("user")]//pathname
        [Authorize]
        public IActionResult Secured1Endpoint()
        {
            return Ok("This is for registered and logged in users only");
        }

        [HttpGet("admin")]//pathname
        [Authorize(Roles ="admin")]
        public IActionResult Secured2Endpoint()
        {
            return Ok("This is for  admin users only");
        }
    }
}
