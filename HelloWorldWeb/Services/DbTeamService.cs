// <copyright file="DbTeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

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

        public int AddTeamMember(string name)
        {
            TeamMember newMember = new TeamMember() { Name = name };
            this.context.Add(newMember);
            this.context.SaveChanges();
            return newMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = this.context.TeamMembers.Find(id);
            this.context.TeamMembers.Remove(teamMember);
            this.context.SaveChanges();
        }

        public void EditTeamMemberName(int id, string name)
        {
            var teamMember = this.context.TeamMembers.Find(id);
            teamMember.Name = name;
            this.context.Update(teamMember);
            this.context.SaveChanges();
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
            throw new System.NotImplementedException();
        }
    }
}