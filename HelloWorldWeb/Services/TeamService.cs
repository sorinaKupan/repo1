// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 2",
                TeamMembers = new List<string>(new string[]
               {
                    "Sechei Radu",
                    "Tanase Teona",
                    "Duma Dragos",
                    "Campean Leon",
                    "Naghi Claudia",
                    "Marian George",
               }),
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public void AddTeamMember(string name)
        {
            teamInfo.TeamMembers.Add(name);
        }

    }
}
