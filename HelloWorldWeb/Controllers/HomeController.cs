// <copyright file="HomeController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System.Diagnostics;
using System.Linq;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[Authorize]
public class HomeController : Controller
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly ILogger<HomeController> logger;
#pragma warning restore IDE0052 // Remove unread private members
        private readonly ITeamService teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
        }

        [HttpPost]

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember();
            teamMember.Name = name;
            return this.teamService.AddTeamMember(teamMember);
        }

        [HttpDelete]

        public void DeleteTeamMember(int id)
        {
            this.teamService.DeleteTeamMember(id);
        }

        [HttpPost]

        public int EditTeamMemberName(int id, string name)
        {
            return this.teamService.EditTeamMemberName(id, name);
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count();
        }

        public IActionResult Index()
        {
            var teamInfo = this.teamService.GetTeamInfo();
            return this.View(teamInfo);
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

        public IActionResult Chat()
        {
            return this.View();
        }
    }
