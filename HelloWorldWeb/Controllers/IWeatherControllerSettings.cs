// <copyright file="IWeatherControllerSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWebApp.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { set; get; }

        string Latitude { set; get; }

        string ApiKey { set; get; }
    }
}