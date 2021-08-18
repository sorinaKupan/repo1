// <copyright file="ITeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
            int AddTeamMember(TeamMember teamMember);

            void DeleteTeamMember(int id);

            TeamMember GetTeamMemberById(int id);

            int EditTeamMemberName(int id, string name);

            TeamInfo GetTeamInfo();
    }
}