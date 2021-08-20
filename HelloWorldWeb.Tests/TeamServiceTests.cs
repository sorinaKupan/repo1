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
        private Mock<ITeamService> timeMock;

        private void InitializeTimeServiceMock()
        {
            this.timeMock = new Mock<ITeamService>();
            //this.timeMock.Setup();//finish the mock for MessageHub
        }
      /*  [Fact]
         public void AddTeamMemberToTheTeam()
         {
             // Assume
             ITeamService teamService = this.timeMock.Object;

             // Act
             teamService.AddTeamMember("Sorina");

             // Assert
             Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
         }

         [Fact]
         public void DeleteTeamMember()
         {
             // Assume
             ITeamService teamService = this.timeMock.Object;
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
             ITeamService teamService = this.timeMock.Object;
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
             ITeamService teamService = this.timeMock.Object;
             var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
             var newMemberName = "Boris";

             // Act
             teamService.DeleteTeamMember(memberToBeDeleted.Id);
             var id = teamService.AddTeamMember(newMemberName);
             teamService.DeleteTeamMember(id);

             // Assert
             var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == newMemberName);
             Assert.Null(member);
         }*/
     }
}
