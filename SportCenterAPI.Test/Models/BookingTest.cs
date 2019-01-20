using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportCenterAPI.Models;

namespace SportCenterAPI.Test
{
    [TestClass]
    public class BookingTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Booking booking = new Booking();

            booking.Should().NotBeNull();
            booking.Id.Should().Be(0);
            booking.Member.Should().BeNull();
            booking.Court.Should().BeNull();
            booking.CreatedDate.Should().BeSameDateAs(new DateTime());
            booking.BookingDate.Should().BeSameDateAs(new DateTime());
        }

        [TestMethod]
        public void IdTest()
        {
            Booking booking = new Booking();
            booking.Id = 22;

            booking.Id.Should().Be(22);
        }

        [TestMethod]
        public void CourtTest()
        {

            Court court = new Court();

            Booking booking = new Booking();
            booking.Court = court;

            booking.Court.Should().BeSameAs(court);
        }

        [TestMethod]
        public void MemberTest()
        {

            Member member = new Member();

            Booking booking = new Booking();
            booking.Member = member;

            booking.Member.Should().BeSameAs(member);
        }

        [TestMethod]
        public void CreatedDateTest()
        {
            Booking booking = new Booking();
            booking.CreatedDate = new DateTime(2019, 01, 20, 00, 00, 00);

            booking.CreatedDate.Should().BeSameDateAs(new DateTime(2019, 01, 20, 00, 00, 00));
        }

        [TestMethod]
        public void BookingDateTest()
        {
            Booking booking = new Booking();
            booking.BookingDate = new DateTime(2019, 01, 20, 00, 00, 00);

            booking.BookingDate.Should().BeSameDateAs(new DateTime(2019, 01, 20, 00, 00, 00));
        }
    }
}
