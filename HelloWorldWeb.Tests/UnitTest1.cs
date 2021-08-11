using System;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.AddTeamMember("Sorina");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
            
        }

        [Fact]
        public void DeleteTeamMember()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.DeleteTeamMember(1);

            //Assert

            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberName()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.EditTeamMemberName(3, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);
        }
    }
}
