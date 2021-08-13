// <copyright file="Startup.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using HelloWorldWebApp.Controllers;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public double Longitude { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double Latitude { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ApiKey { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}