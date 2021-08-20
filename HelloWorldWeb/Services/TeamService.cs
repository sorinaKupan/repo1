// <copyright file="TeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly ITimeService timeService;
        private readonly IHubContext<MessageHub> messageHub;

        public TeamService(IHubContext<MessageHub> messageHubContext)
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 2",
                TeamMembers = new List<TeamMember>(),
            };

            this.messageHub = messageHubContext;

            this.AddTeamMember("Sorina");
            this.AddTeamMember("Tudor");
            this.AddTeamMember("Ema");
            this.AddTeamMember("Patrick");
            this.AddTeamMember("Radu");
            this.AddTeamMember("Fineas");
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

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new (name, this.timeService);
            this.teamInfo.TeamMembers.Add(teamMember);
            this.messageHub.Clients.All.SendAsync("TeamMemberAdded", teamMember.Name, teamMember.Id);
            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
        }

        public void EditTeamMemberName(int id, string name)
        {
            this.GetTeamMemberById(id).Name = name;
        }
    }
}
