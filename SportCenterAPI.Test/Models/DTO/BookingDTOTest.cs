using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportCenterAPI.Models.DTO.Test
{
    [TestClass]
    public class BookingDTOTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            BookingDTO booking = new BookingDTO();

            booking.Should().NotBeNull();
            booking.MemberId.Should().Be(0);
            booking.CourtId.Should().Be(0);
            booking.SportId.Should().Be(0);
            booking.BookingDate.Should().BeSameDateAs(new DateTime());
        }

        [TestMethod]
        public void MemberIdTest()
        {
            BookingDTO booking = new BookingDTO();
            booking.MemberId = 2;

            booking.MemberId.Should().Be(2);
        }

        [TestMethod]
        public void CourtIdTest()
        {
            BookingDTO booking = new BookingDTO();
            booking.CourtId = 2;

            booking.CourtId.Should().Be(2);
        }

        [TestMethod]
        public void SportIdTest()
        {
            BookingDTO booking = new BookingDTO();
            booking.SportId = 2;

            booking.SportId.Should().Be(2);
        }

        [TestMethod]
        public void BookingDateTest()
        {
            BookingDTO booking = new BookingDTO();
            booking.BookingDate = new DateTime(2019, 01, 20, 00, 00, 00);

            booking.BookingDate.Should().BeSameDateAs(new DateTime(2019, 01, 20, 00, 00, 00));
        }
    }
}
