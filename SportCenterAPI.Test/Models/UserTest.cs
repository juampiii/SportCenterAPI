using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportCenterAPI.Models;

namespace SportCenterAPI.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            User user = new User();

            user.Should().NotBeNull();
            user.Id.Should().Be(0);
            user.Name.Should().BeNull();
            user.Password.Should().BeNull();
        }

        [TestMethod]
        public void IdTest()
        {
            User user = new User();
            user.Id = 22;

            user.Id.Should().Be(22);
        }

        [TestMethod]
        public void NameTest()
        {
            User user = new User();
            user.Name = "Chuck Norris";

            user.Name.Should().Be("Chuck Norris");
        }

        [TestMethod]
        public void PasswordTest()
        {
            User user = new User();
            user.Password = "********";

            user.Password.Should().Be("********");
        }

        [TestMethod]
        public void CreatedDateTest()
        {
            User user = new User();
            user.CreatedDate = new DateTime(2019, 01, 20, 00, 00, 00);

            user.CreatedDate.Should().BeSameDateAs(new DateTime(2019, 01, 20, 00, 00, 00));
        }
    }
}
