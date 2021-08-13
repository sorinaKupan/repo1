// <copyright file="WeatherControllerSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb
{
    using HelloWorldWebApp.Controllers;
    using Microsoft.Extensions.Configuration;

    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration conf)
        {
            this.ApiKey = conf["WeatherForecast:ApiKey"];
            this.Latitude = conf["WeatherForecast:Latitude"];
            this.Longitude = conf["WeatherForecast:Longitude"];
        }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string ApiKey { get; set; }
    }
}