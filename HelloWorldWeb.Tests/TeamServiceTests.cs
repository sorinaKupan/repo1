// <copyright file="TeamServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Tests
{
    using System;
    using HelloWorldWeb.Models;
    using HelloWorldWeb.Services;
    using Moq;
    using Xunit;

    public class TeamServiceTests
    {
        private IBroadcastService broadcastService;

        [Fact]
         public void AddTeamMemberToTheTeam()
         {
            // Assume
             Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
             broadcastService = broadcastServiceMock.Object;
             ITeamService teamService = new TeamService(broadcastService);
            TeamMember teamMember = new TeamMember();

            // Act
            teamMember.Name = "Sorin";
             teamService.AddTeamMember(teamMember);

             // Assert
             Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
            broadcastServiceMock.Verify(_ => _.TeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.AtLeastOnce());
         }

         [Fact]
         public void DeleteTeamMember()
         {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
            var targetTeamMember = teamService.GetTeamInfo().TeamMembers[0];
             var memberId = targetTeamMember.Id;

             // Act
             teamService.DeleteTeamMember(memberId);

             // Assert
             Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
         }

         [Fact]
         public void EditTeamMemberName()
         {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
            var targetTeamMember = teamService.GetTeamInfo().TeamMembers[0];
             var memberId = targetTeamMember.Id;

             // Act
             teamService.EditTeamMemberName(memberId, "NewName");

             // Assert
             Assert.Equal("NewName", teamService.GetTeamMemberById(memberId).Name);
         }

         [Fact]
         public void CheckIdProblem()
         {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
             var newMemberName = "Boris";
            TeamMember teamMember = new TeamMember();

            // Act
            teamMember.Name = newMemberName;
             teamService.DeleteTeamMember(memberToBeDeleted.Id);
             var id = teamService.AddTeamMember(teamMember);
             teamService.DeleteTeamMember(id);

             // Assert
             var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == newMemberName);
             Assert.Null(member);
         }
     }
}
