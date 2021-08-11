// <copyright file="TeamMember.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using HelloWorldWeb.Services;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        private readonly ITimeService timeService;
        private static int idCounter = 0;
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

        public int getAge()
        {
            TimeSpan age;
            DateTime birthDate;
            birthDate = this.BirthDate;

            DateTime zeroTime = new DateTime(1, 1, 1);
            age = timeService.Now() - birthDate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }
    }
}