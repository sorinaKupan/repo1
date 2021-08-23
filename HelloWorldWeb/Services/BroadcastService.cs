using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class BroadcastService : IBroadcastService
    {
        private readonly IHubContext<MessageHub> messageHub;

        public BroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void TeamMemberAdded(string name, int id)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberAdded", name, id);
        }

        public void TeamMemberDeleted(int id)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberDeleted", id);
        }

        public void TeamMemberEdit(int id, string name)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberEdit", name, id);
        }
    }
}
