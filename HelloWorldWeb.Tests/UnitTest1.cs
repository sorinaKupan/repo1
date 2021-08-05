using System;
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
    }
}
