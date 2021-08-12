using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 08, 11));
            
        }

        [Fact]
        public void TestGetAgeEqual()
        {
            // Assume
            InitializeTimeServiceMock();
            var timeService = timeMock.Object;
            TeamMember teamMember = new TeamMember("Ioan", timeService);
            teamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 21;

            // Act
            int computedAge = teamMember.getAge();

            // Assert
            Assert.Equal(expectedAge, computedAge);
            timeMock.Verify(_ => _.Now(), Times.Once());
        }
    }
}
