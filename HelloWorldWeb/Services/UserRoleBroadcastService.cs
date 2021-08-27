// <copyright file="UserRoleBroadcastService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class UserRoleBroadcastService : IUserRoleBroadcastService
    {
        private readonly IHubContext<MessageHub> messageHub;

        public UserRoleBroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void AssignedAdminRole(string id)
        {
            this.messageHub.Clients.All.SendAsync("AssignedAdminRole", id);
        }

        public void AssignedUserRole(string id)
        {
            this.messageHub.Clients.All.SendAsync("AssignedUserRole", id);
        }
    }
}
