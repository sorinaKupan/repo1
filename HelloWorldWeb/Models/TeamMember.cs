// <copyright file="TeamMember.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public static int idCount = 0;
        public TeamMember( string name)
        {
            this.Id = idCount;
            this.Name = name;
            idCount++;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}