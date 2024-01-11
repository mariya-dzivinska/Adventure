using Adventure.Business;
using Adveture.WebApiProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adveture.WebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private static readonly string[] RequieredPermissions = new[]
        {
            "CreateOrder", "ViewOrder", "RemoveOrder", "SendMessage"
        };

        private readonly ITeachersService _teachersService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ITeachersService teachersService)
        {
            _logger = logger;
            _teachersService = teachersService;
        }

        [HttpGet("{id:int}")]
        [CustomActionFilter()]
        [CustomExceptionFilter]
        [Permission("Read")]
        public TeacherDto GetTeacherById(int id)
        {
            return _teachersService.GetTeacherDtos(id);
        }



        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut("teachers/{teacherId:int}/course/{courseId:int}")]
        public string GetId(int teacherId, int courseId, [FromQuery]Temp dto)
        {
            return "hello";
        }


    }

    public class Temp
    {
        public string Name { get; set; }
    }
}