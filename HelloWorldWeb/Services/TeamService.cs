// <copyright file="TeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;

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
            return this.teamInfo;
        }

        public void AddTeamMember(string name)
        {
            this.teamInfo.TeamMembers.Add(name);
        }
        public void DeleteTeamMember(int index)
        {
            this.teamInfo.TeamMembers.RemoveAt(index);
        }
    }
}
