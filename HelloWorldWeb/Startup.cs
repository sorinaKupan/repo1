// <copyright file="Startup.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Reflection;
using HelloWorldWeb;
using HelloWorldWeb.Data;
using HelloWorldWeb.Services;
using HelloWorldWebApp.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static string ConvertHerokuStringToAspnetString(string herokuConnectionString)
        {
            var databaseUri = new Uri(herokuConnectionString);
            var databaseUriUsername = databaseUri.UserInfo;
            var databaseUsername = databaseUriUsername.Split(":")[0];
            var databasePassword = databaseUriUsername.Split(":")[1];
            var databaseName = databaseUri.LocalPath.TrimStart('/');
            return $"Host = {databaseUri.Host}; Port = {databaseUri.Port}; Database = {databaseName}; Integrated Security = true; User Id = {databaseUsername}; Password = {databasePassword}; Pooling = True; SSL Mode = Require; TrustServerCertificate = True; Include Error Detail = True";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITeamService, DbTeamService>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddSingleton<IBroadcastService, BroadcastService>();
            services.AddSingleton<IUserRoleBroadcastService, UserRoleBroadcastService>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddSingleton<IWeatherControllerSettings, WeatherControllerSettings>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hello World API", Version = "v1" });

            // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        });

            this.AssignRoleProgramaticaly(services.BuildServiceProvider());
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<MessageHub>("/messagehub");
                endpoints.MapRazorPages();
            });
        }

        private async void AssignRoleProgramaticaly(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var user = await userManager.FindByEmailAsync("sorinakupan3@gmail.com");
        await userManager.AddToRoleAsync(user, "Administrator");
    }
}
