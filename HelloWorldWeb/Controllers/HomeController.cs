﻿using System;
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
            _logger = logger;
            teamInfo = new TeamInfo
            {
                Name = "Team2",
                TeamMembers = new List<string>(new string[] { "Gabriel", "Delia", "Sorina", "Rares", "Catalin" })
            };
        }

        [HttpGet]
        public void AddTeamMember(string name)
        {
            teamInfo.TeamMembers.Add(name);
        }

        [HttpGet]
        public int GetCount()
        {
            return teamInfo.TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return View(teamInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
