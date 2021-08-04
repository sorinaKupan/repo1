// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        
            void AddTeamMember(string name);

            TeamInfo GetTeamInfo();
    }
    
}