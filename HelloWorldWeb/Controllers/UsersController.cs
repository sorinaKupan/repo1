// <copyright file="UsersController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            List<UserWithRole> userWithRoles = new List<UserWithRole>();
            var allUsers = await this.userManager.Users.ToListAsync();

            var administrators = await this.userManager.GetUsersInRoleAsync("Administrators");
            var commonUsers = allUsers.Except(administrators).ToList();
            foreach (var admin in administrators)
            {
                UserWithRole dummy = new UserWithRole() { UserId = admin.Id, UserName = admin.UserName, RoleName = "Administrators" };
                userWithRoles.Add(dummy);
            }

            foreach (var user in commonUsers)
            {
                UserWithRole dummy = new UserWithRole() { UserId = user.Id, UserName = user.UserName, RoleName = "Users" };
                userWithRoles.Add(dummy);
            }

            return this.View(userWithRoles);
        }

        public async Task<IActionResult> AssignAdminRole(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            await this.userManager.RemoveFromRoleAsync(user, "Users");
            await this.userManager.AddToRoleAsync(user, "Administrators");
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> AssignUsualRole(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            await this.userManager.RemoveFromRoleAsync(user, "Administrators");
            await this.userManager.AddToRoleAsync(user, "Users");
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
