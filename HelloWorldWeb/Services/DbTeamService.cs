// <copyright file="DbTeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public DbTeamService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int AddTeamMember(string name)
        {
            TeamMember newMember = new TeamMember(name);
            this._context.Add(newMember);
            this._context.SaveChangesAsync();
            return newMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = _context.TeamMembers.Find(id);
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
        }

        public void EditTeamMemberName(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name ="My team";
            teamInfo.TeamMembers = this._context.TeamMembers.ToList();
            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}