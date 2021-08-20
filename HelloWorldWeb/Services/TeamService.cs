// <copyright file="TeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    using System;
    using System.Collections.Generic;
    using HelloWorldWeb.Models;

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
            this.teamInfo.TeamMembers.Add(new TeamMember("Iuliana"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Ema"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Radu"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Patrick"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Tudor"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Fineas"));
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public int AddTeamMember(TeamMember teamMember)
        {
            this.teamInfo.TeamMembers.Add(teamMember);
            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
        }

        public int EditTeamMemberName(int id, string name)
        {
            this.GetTeamMemberById(id).Name = name;
            return id;
        }
    }
}
