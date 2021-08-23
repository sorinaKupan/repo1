// <copyright file="TeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void TeamMemberAdded(string name, int id);
        void TeamMemberDeleted(int id);
    }
}