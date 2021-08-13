// <copyright file="IWeatherControllerSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWebApp.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { get; set; }

        string Latitude { get; set; }

        string ApiKey { get; set; }
    }
}