using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportCenterAPI.Models;

namespace SportCenterAPI.Test
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Member member = new Member();

            member.Should().NotBeNull();
            member.Id.Should().Be(0);
            member.Name.Should().BeNull();
            member.Password.Should().BeNull();
            member.Phone.Should().BeNull();
            member.Bookings.Should().NotBeNull();
            member.Bookings.Count().Should().Be(0);
        }

        [TestMethod]
        public void PhoneTest()
        {
            Member member = new Member();
            member.Phone = "647222345";

            member.Phone.Should().Be("647222345");
        }

        [TestMethod]
        public void BookingsTest()
        {
            Booking booking = new Booking();

            Member member = new Member();
            member.Bookings.Add(booking);

            member.Bookings.Count().Should().Be(1);
            member.Bookings.ElementAt(0).Should().BeSameAs(booking);
        }
    }
}
