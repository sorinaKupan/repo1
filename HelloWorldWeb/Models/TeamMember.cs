// <copyright file="TeamMember.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    using System;
    using System.Diagnostics;
    using HelloWorldWeb.Services;

    [DebuggerDisplay("{Name}[{Id}]")]
    public class TeamMember
    {
        private static int idCounter = 0;
        private readonly ITimeService timeService;

        public TeamMember()
        {
        }

        public TeamMember(string name, ITimeService timeService)
        {
            this.Id = idCounter;
            this.Name = name;
            this.timeService = timeService;
            idCounter++;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public static int GetIdCounter()
        {
            return idCounter;
        }

        public int GetAge()
        {
            TimeSpan age;
            DateTime birthDate;
            birthDate = this.BirthDate;

            DateTime zeroTime = new DateTime(1, 1, 1);
            age = this.timeService.Now() - birthDate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }
    }
}