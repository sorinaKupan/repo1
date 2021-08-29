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
            List<UserWithRole> userWithRoles = new ();
            var allUsers = await this.userManager.Users.ToListAsync();

            var administrators = await this.userManager.GetUsersInRoleAsync("Administrator");
            var commonUsers = allUsers.Except(administrators).ToList();
            foreach (var admin in administrators)
            {
                UserWithRole dummy = new () { UserId = admin.Id, UserName = admin.UserName, RoleName = "Administrator" };
                userWithRoles.Add(dummy);
            }

            foreach (var user in commonUsers)
            {
                UserWithRole dummy = new () { UserId = user.Id, UserName = user.UserName, RoleName = "User" };
                userWithRoles.Add(dummy);
            }

            return this.View(userWithRoles);
        }

        public async Task<IActionResult> AssignAdminRole(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            await this.userManager.RemoveFromRoleAsync(user, "User");
            await this.userManager.AddToRoleAsync(user, "Administrator");
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> AssignUsualRole(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            await this.userManager.RemoveFromRoleAsync(user, "Administrator");
            await this.userManager.AddToRoleAsync(user, "User");
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
