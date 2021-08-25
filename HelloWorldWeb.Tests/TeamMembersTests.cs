using System;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMembersTests
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.AddTeamMember(new TeamMember() { Name = "Sorina" });

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

            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberName()
        {
            //Assume
            ITeamService teamService = new TeamService();
            int givenId = 2000;
            string newName = "NewName";
            TeamMember newTeamMember = new TeamMember(givenId, "New");
            teamService.AddTeamMember(newTeamMember);
            //Act
            teamService.EditTeamMemberName(givenId, newName);

            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(givenId).Name);
           
        }

        [Fact]
        public void CheckIdProblem()
        {
            // Assume
            ITeamService teamService = new TeamService();
            int givenId = 2000;

            // Act
            TeamMember newTeamMember = new TeamMember(givenId, "Boris");
            teamService.AddTeamMember(newTeamMember);
            teamService.DeleteTeamMember(givenId);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(givenId));
        } 
    }
}
