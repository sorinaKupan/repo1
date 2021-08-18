// <copyright file="TeamMember.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    using System;

    public class TeamMember
    {
        private static int idCounter = 0;

        public TeamMember()
        {
        }

        public TeamMember(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public TeamMember(string name)
        {
            this.Id = idCounter;
            this.Name = name;

            idCounter++;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public static int GetIdCounter()
        {
            return idCounter;
        }

        public override bool Equals(object obj)
        {
            TeamMember comparableMember = (TeamMember)obj;
            return this.Id.Equals(comparableMember.Id) &&
                   this.Name.Equals(comparableMember.Name);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}