// <copyright file="IUserRoleBroadcastService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    public interface IUserRoleBroadcastService
    {
        void AssignedUserRole(string id);

        void AssignedAdminRole(string id);
    }
}
