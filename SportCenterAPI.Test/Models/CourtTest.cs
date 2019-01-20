using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportCenterAPI.Models;

namespace SportCenterAPI.Test
{
    [TestClass]
    public class CourtTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Court court = new Court();

            court.Should().NotBeNull();
            court.Id.Should().Be(0);
            court.Name.Should().BeNull();
            court.Sport.Should().BeNull();
            court.Bookings.Should().NotBeNull();
            court.Bookings.Count().Should().Be(0);
        }

        [TestMethod]
        public void IdTest()
        {
            Court court = new Court();
            court.Id = 22;

            court.Id.Should().Be(22);
        }

        [TestMethod]
        public void NameTest()
        {
            Court court = new Court();
            court.Name = "Court 01";

            court.Name.Should().Be("Court 01");
        }

        [TestMethod]
        public void SportTest()
        {
            Sport sport = new Sport();

            Court court = new Court();
            court.Sport = sport;

            court.Sport.Should().BeSameAs(sport);
        }

        [TestMethod]
        public void BookingsTest()
        {
            Booking booking = new Booking();

            Court court = new Court();
            court.Bookings.Add(booking);

            court.Bookings.Count().Should().Be(1);
            court.Bookings.ElementAt(0).Should().BeSameAs(booking);
        }
    }
}
