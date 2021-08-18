using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToASPNETString()
        {
            //Assume
            string herokuConnectionString = "postgres://yzryivcghhxahc:b07ef957f04ac43122005d9e9acf3625b3fd7b9bd39666bcadf1fb50617602ac@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/dflb5fjib21hav";
            //Act
            string aspnetConnectionString = Startup.ConvertHerokuStringToAspnetString(herokuConnectionString);

            //Assert
            Assert.Equal("Host = ec2-34-251-245-108.eu-west-1.compute.amazonaws.com; Port = 5432; Database = dflb5fjib21hav; Integrated Security = true; User Id = yzryivcghhxahc; Password = b07ef957f04ac43122005d9e9acf3625b3fd7b9bd39666bcadf1fb50617602ac; Pooling = True; SSL Mode = Require; TrustServerCertificate = True; Include Error Detail = True", aspnetConnectionString);
        }
    }
}
