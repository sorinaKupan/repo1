// <copyright file="DbTeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;

        public DbTeamService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddTeamMember(TeamMember teamMember)
        {
            this.context.Add(teamMember);
            this.context.SaveChanges();
            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = this.context.TeamMembers.Find(id);
            this.context.TeamMembers.Remove(teamMember);
            this.context.SaveChanges();
        }

        public int EditTeamMemberName(int id, string name)
        {
            int returnId = -1;
            TeamMember existingMember = this.GetTeamMemberById(id);

            if (existingMember != null)
            {
                existingMember.Name = name;
                returnId = id;
            }

            this.context.SaveChanges();
            return returnId;
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name = "My team";
            teamInfo.TeamMembers = this.context.TeamMembers.ToList();
            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            List<TeamMember> members = this.context.TeamMembers.ToList();
            foreach (TeamMember member in members)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
        }
    }
}