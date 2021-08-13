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
        public const double KELVIN_CONST = 273.15;

        public WeatherController(IWeatherControllerSettings weatherControllerSettings)
        {
            this.longitude = weatherControllerSettings.Longitude;
            this.latitude = weatherControllerSettings.Latitude;
            this.apiKey = weatherControllerSettings.ApiKey;
        }
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
        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            var jsonArray = json["daily"].Take(7);
            return jsonArray.Select(CreateDailyWeatherRecordFromJToken);
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
            var temperature = (decimal)(item.SelectToken("temp").Value<float>("day") - KELVIN_CONST);
            var type = Convert(item.SelectToken("weather")[0].Value<string>("description"));

            DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(day, temperature, type);
            return dailyWeatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "freezing":
                    return WeatherType.Freezing;
                case "bracing":
                    return WeatherType.Bracing;
                case "chilly":
                    return WeatherType.Chilly;
                case "cool":
                    return WeatherType.Cool;
                case "mild":
                    return WeatherType.Mild;
                case "balmy":
                    return WeatherType.Balmy;
                case "hot":
                    return WeatherType.Hot;
                case "sweltering":
                    return WeatherType.Sweltering;
                case "scorching":
                    return WeatherType.Scorching;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                case "few clouds":
                    return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}