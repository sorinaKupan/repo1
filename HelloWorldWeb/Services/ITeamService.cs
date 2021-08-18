// <copyright file="ITeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    using HelloWorldWeb.Models;

    public interface ITeamService
    {
            int AddTeamMember(TeamMember teamMember);

            void DeleteTeamMember(int id);

            TeamMember GetTeamMemberById(int id);

            int EditTeamMemberName(int id, string name);

            TeamInfo GetTeamInfo();
    }
}