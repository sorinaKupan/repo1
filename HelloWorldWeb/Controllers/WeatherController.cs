using HelloWorldWweb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly double latitude= 46.7700;
        private readonly double longitude= 23.5800;
        private readonly string apiKey= "bfe996606177703436b8ea1351e2bf09";

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            //lat 46.7700 lon 23.5800
            //https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=bfe996606177703436b8ea1351e2bf09

            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);
            return new DailyWeatherRecord[] { 
            new DailyWeatherRecord(new DateTime(2021, 08, 12), (decimal)22.0, WeatherType.Mild),
            new DailyWeatherRecord(new DateTime(2021, 08, 13), (decimal)22.0, WeatherType.Mild)
            };
        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            return new DailyWeatherRecord[] {
            new DailyWeatherRecord(new DateTime(2021, 08, 12), (decimal)22.0, WeatherType.Mild),
            new DailyWeatherRecord(new DateTime(2021, 08, 13), (decimal)22.0, WeatherType.Mild)
            };
        }
        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}