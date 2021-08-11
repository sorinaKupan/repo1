using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        [Fact]
        public void TestGetAgeEqual()
        {
            // Assume
            var newTeamMember = new TeamMember(10, "Boris");
            newTeamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 21;

            // Act
            int computedAge = newTeamMember.getAge();

            // Assert
            Assert.Equal(expectedAge, computedAge);
        }
    }
}
