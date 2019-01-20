using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportCenterAPI.Models;

namespace SportCenterAPI.Test
{
    [TestClass]
    public class SportTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Sport sport = new Sport();

            sport.Should().NotBeNull();
            sport.Id.Should().Be(0);
            sport.Name.Should().BeNull();
            sport.Courts.Should().NotBeNull();
            sport.Courts.Count().Should().Be(0);
        }

        [TestMethod]
        public void IdTest()
        {
            Sport sport = new Sport();
            sport.Id = 22;

            sport.Id.Should().Be(22);
        }

        [TestMethod]
        public void NameTest()
        {
            Sport sport = new Sport();
            sport.Name = "Kabaddi";

            sport.Name.Should().Be("Kabaddi");
        }

        [TestMethod]
        public void CourtsTest()
        {
            Court court = new Court();

            Sport sport = new Sport();
            sport.Courts.Add(court);

            sport.Courts.Count.Should().Be(1);
            sport.Courts.ElementAt(0).Should().BeSameAs(court);
        }
    }
}
