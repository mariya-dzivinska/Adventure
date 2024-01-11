using Adventure.WebApi.Attributes;
using LeaningPass.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Adventure.WebApi.Controllers
{
    [ApiController]
    [Log]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITeacherRepository _teacherRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITeacherRepository teacherRepository)
        {
            _logger = logger;
            _teacherRepository = teacherRepository;
        }

        [ExAttribute]
        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WeatherForecast>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("hello");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id)
        {
            var isUpdated = await UpdateForsecast(id);
            return isUpdated;
            
        }

        [HttpGet("{id}")]
        public async Task<Teacher> GetTeacher(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            return teacher;

        }

        private async Task<bool> UpdateForsecast(int id)
        {
            return true;
        }
        
    }
}