﻿// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TeamInfo teamInfo;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
            this.teamInfo = new TeamInfo
            {
                Name = "Team2",
                TeamMembers = new List<string>(new string[] { "Gabriel", "Delia", "Sorina", "Rares", "Catalin" })
            };
        }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            this.teamInfo.TeamMembers.Add(name);
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamInfo.TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(this.teamInfo);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
