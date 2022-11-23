using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using ISRAPI;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IJobService _jobService;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        //[HttpGet(Name = "WeatherForecast")]
        //public IEnumerable<WebApplication5.WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet(Name = "GetAllJob")]
        //public IList<JobDto> Get()
        //{
        //    try
        //    {
        //        var allJobs = _jobService.GetAllJob();
        //        var jobDtoList = allJobs.Response.Select(job => job.ToJobDto()).ToList();

        //        return new List<JobDto>(jobDtoList);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
           
        //}



    }
}