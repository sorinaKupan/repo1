﻿// <copyright file="UsersController.cs" company="Principal33">
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

        /* // GET: Users/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var user = await _context.User
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (user == null)
             {
                 return NotFound();
             }

             return View(user);
         }

         // GET: Users/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Users/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Id,Name,Role")] User user)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(user);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(user);
         }

         // GET: Users/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var user = await _context.User.FindAsync(id);
             if (user == null)
             {
                 return NotFound();
             }
             return View(user);
         }

         // POST: Users/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role")] User user)
         {
             if (id != user.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(user);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!UserExists(user.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(user);
         }

         // GET: Users/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var user = await _context.User
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (user == null)
             {
                 return NotFound();
             }

             return View(user);
         }

         // POST: Users/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var user = await _context.User.FindAsync(id);
             _context.User.Remove(user);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool UserExists(int id)
         {
             return _context.User.Any(e => e.Id == id);
         }
     }*/
    }
}
