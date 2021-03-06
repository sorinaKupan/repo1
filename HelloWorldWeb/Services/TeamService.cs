// <copyright file="TeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly IBroadcastService broadcastService;

        public TeamService(IBroadcastService broadcastService)
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 2",
                TeamMembers = new List<TeamMember>(),
            };

            this.broadcastService = broadcastService;

            this.AddTeamMember(new TeamMember("Sorina"));
            this.AddTeamMember(new TeamMember("Tudor"));
            this.AddTeamMember(new TeamMember("Ema"));
            this.AddTeamMember(new TeamMember("Patrick"));
            this.AddTeamMember(new TeamMember("Radu"));
            this.AddTeamMember(new TeamMember("Fineas"));
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
            this.broadcastService.TeamMemberAdded(teamMember.Name, teamMember.Id);
            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
            this.broadcastService.TeamMemberDeleted(id);
        }

        public int EditTeamMemberName(int id, string name)
        {
            this.GetTeamMemberById(id).Name = name;
            this.broadcastService.TeamMemberEdit(id, name);
            return id;
        }
    }
}
