using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWweb.Models
{
    public class DailyWeatherRecord
    {
        public DailyWeatherRecord(DateTime day, decimal temperature, WeatherType type)
        {
            this.Day = day;
            this.Temperature = temperature;
            this.Type = type;
        }

        public decimal Temperature { get; set; }
        public WeatherType Type { get; set; }
        public DateTime Day { get; set; }
    }
}