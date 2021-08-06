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
                TeamMembers = new List<TeamMember>(),
            };
#pragma warning disable SA1101 // Prefix local calls with this
            teamInfo.TeamMembers.Add(new TeamMember(1, "Tudor"));
            teamInfo.TeamMembers.Add(new TeamMember(2, "Sorina"));
            teamInfo.TeamMembers.Add(new TeamMember(3, "Ema"));
            teamInfo.TeamMembers.Add(new TeamMember(4, "Patrick"));
            teamInfo.TeamMembers.Add(new TeamMember(5, "Radu"));
            teamInfo.TeamMembers.Add(new TeamMember(5, "Fineas"));
#pragma warning restore SA1101 // Prefix local calls with this
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public int AddTeamMember(string name)
        {
            int newId = this.teamInfo.TeamMembers.Count() + 1;
            this.teamInfo.TeamMembers.Add(new TeamMember(newId, name));
            return newId;
        }

        public void DeleteTeamMember(TeamMember teamMember)
        {
            this.teamInfo.TeamMembers.Remove(teamMember);
        }
    }
}
