using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public interface IUserRoleBroadcastService
    {
        void AssignedUserRole(string id);

        void AssignedAdminRole(string id);
    }
}
