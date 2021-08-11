// <copyright file="TeamMember.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public TeamMember(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int getAge()
        {
            var age = DateTime.Now.Subtract(BirthDate).Days;
            age = age / 365;
            return age;
        }
    }
}