using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportCenterAPI.Data;
using SportCenterAPI.Models.DTO;

namespace SportCenterAPI.Models.Manager
{
    [TestClass]
    public class BookingManagerTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager")
                            .Options;

            var booking = new Booking();

            // Run the test against one instance of the context
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);
                manager.Should().NotBeNull();
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task AddTestAsync()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_AddTestAsync")
                            .Options;

            // Example element
            var booking = new Booking()
            {
                BookingDate = new System.DateTime(2019, 10, 10, 0, 0, 0)
            };

            // Add the element
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);
                await manager.Add(booking);
            }

            //Checks if exists in the context
            using (var context = new SportCenterDBContext(options))
            {
                context.Bookings.Should().NotBeNull();
                context.Bookings.Count().Should().Be(1);
                context.Bookings.First().BookingDate.Should().BeSameDateAs(new System.DateTime(2019, 10, 10, 0, 0, 0));
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task AddBookingMemberAsyncTestAsync()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_AddBookingMemberAsyncTestAsync")
                            .Options;

            // Example element
            var booking = new BookingDTO()
            {
                BookingDate = new System.DateTime(2019, 10, 10, 0, 0, 0),
                CourtId = 1,
                MemberId = 2,
            };

            // Add the element
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);
                await manager.AddBookingMemberAsync(booking);
            }

            //Checks if exists in the context
            using (var context = new SportCenterDBContext(options))
            {
                context.Bookings.Should().NotBeNull();
                context.Bookings.Count().Should().Be(1);
                context.Bookings.First().BookingDate.Should().BeSameDateAs(new System.DateTime(2019, 10, 10, 0, 0, 0));
                context.Bookings.First().CourtForeignKey.Should().Be(1);
                context.Bookings.First().MemberForeignKey.Should().Be(2);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task DeleteAsyncTestAsync()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_DeleteAsyncTestAsync")
                            .Options;

            // Example element
            var booking = new Booking()
            {
                BookingDate = new System.DateTime(2019, 10, 10, 0, 0, 0),
                Id = 1
            };

            // Add the element
            using (var context = new SportCenterDBContext(options))
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }

            // Delete the element
            using (var context = new SportCenterDBContext(options))
            {

                var manager = new BookingManager(context);
                var exist = await manager.Exist(1);
                exist.Should().Be(true);

                await manager.DeleteAsync(1);

                exist = await manager.Exist(1);
                exist.Should().BeFalse();
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ExistTestAsync()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_ExistTestAsync")
                            .Options;

            // Example element
            var booking = new Booking()
            {
                BookingDate = new System.DateTime(2019, 10, 10, 0, 0, 0),
                Id = 1
            };

            // Add the element
            using (var context = new SportCenterDBContext(options))
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }

            // Checks if the element exists
            using (var context = new SportCenterDBContext(options))
            {

                var manager = new BookingManager(context);
                var exist = await manager.Exist(1);
                exist.Should().BeTrue();
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetAllTestAsync()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_GetAllTestAsync")
                            .Options;

            // Add the elements
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1, Name = "Manolo"});
                context.Courts.Add(new Court() { Id = 1 , Sport = new Sport() { Id = 1} });
                context.Bookings.Add(new Booking() { Id = 1, MemberForeignKey = 1, CourtForeignKey = 1 });
                context.Bookings.Add(new Booking() { Id = 2, MemberForeignKey = 1, CourtForeignKey = 1, BookingDate = new DateTime(2019, 1, 1) });
                context.SaveChanges();
            }

            // Get All the Elements
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);
                var elements = await manager.GetAll();
                elements.Count().Should().Be(2);
                elements.ElementAt(0).Id.Should().Be(1);
                elements.ElementAt(1).Id.Should().Be(2);
            }
        }

        [TestMethod]
        public void GetDailyBookingsTest()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_GetDailyBookingsTest")
                            .Options;

            // Add the elements
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1 });
                context.Courts.Add(new Court() { Id = 1 , Sport = new Sport() { Id = 1 } });
                context.Bookings.Add(new Booking() { Id = 1, MemberForeignKey = 1, CourtForeignKey = 1, BookingDate = new DateTime(2019, 1, 19, 11, 00, 00) });
                context.Bookings.Add(new Booking() { Id = 2, MemberForeignKey = 1, CourtForeignKey = 1, BookingDate = new DateTime(2019, 1, 19, 10, 00, 00) });
                context.Bookings.Add(new Booking() { Id = 3, MemberForeignKey = 1, CourtForeignKey = 1, BookingDate = new DateTime(2019, 1, 10, 10, 00, 00) });
                context.SaveChanges();
            }

            // Get the Elements
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);
                var elements = manager.GetDailyBookings(new DateTime(2019, 1, 19, 11, 00, 00));
                elements.Count().Should().Be(2);
                elements.ElementAt(0).Id.Should().Be(1);
                elements.ElementAt(1).Id.Should().Be(2);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task UpdateTestAsync()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_UpdateTestAsync")
                            .Options;

            // Example element
            var booking = new Booking()
            {
                Id = 1,
                BookingDate = new DateTime(2019, 10, 10, 0, 0, 0),
                CreatedDate = new DateTime(2019, 10, 10, 0, 0, 0),
                CourtForeignKey = 1,
                MemberForeignKey = 1
            };

            // Add the element
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1 });
                context.Courts.Add(new Court() { Id = 1, Sport = new Sport() { Id = 1 } });
                context.Bookings.Add(booking);
                context.SaveChanges();
            }

            // Update the value and checks before and after
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);

                var original = await manager.Get(1);
                original.CreatedDate.Should().BeSameDateAs(new DateTime(2019, 10, 10, 0, 0, 0));

                original.CreatedDate = new DateTime(2019, 10, 11, 0, 0, 0);

                await manager.Update(1, original);

                var modified = await manager.Get(1);
                modified.CreatedDate.Should().BeSameDateAs(new DateTime(2019, 10, 11, 0, 0, 0));
            }
        }

        [TestMethod]
        public void BookingAlreadyExistTest()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_BookingAlreadyExistTest")
                            .Options;

            // Example element
            var booking = new Booking()
            {
                Id = 1,
                BookingDate = new DateTime(2019, 10, 10, 0, 0, 0),
                CreatedDate = new DateTime(2019, 10, 10, 0, 0, 0),
                CourtForeignKey = 1,
                MemberForeignKey = 1
            };

            // Add the element
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1 });
                context.Courts.Add(new Court() { Id = 1, Sport = new Sport() { Id = 1 } });
                context.Bookings.Add(booking);
                context.SaveChanges();
            }

            // Update the value and checks before and after
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);

                var exists = manager.BookingAlreadyExist(1, new DateTime(2019, 10, 10, 0, 0, 0));
                exists.Should().BeTrue();

                var nonExists = manager.BookingAlreadyExist(1, new DateTime(2019, 10, 11, 0, 0, 0));
                nonExists.Should().BeFalse();
            }
        }

        [TestMethod]
        public void BookingMemberAllowedTest()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_BookingMemberAllowedTest")
                            .Options;

            // Add the elements
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1 });
                context.Courts.Add(new Court() { Id = 1, Sport = new Sport() { Id = 1 } });
                context.SaveChanges();
            }

            // Checks if the user is allowed to perform the booking
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);

                var exists = manager.BookingMemberAllowed(1, new DateTime(2019, 10, 10, 10, 0, 0));
                exists.Should().BeTrue();
            }
        }

        [TestMethod]
        public void BookingMemberNotAllowedMaxDailyTest()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_BookingMemberNotAllowedMaxDailyTest")
                            .Options;

            // Add the elements
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1 });
                context.Courts.Add(new Court() { Id = 1, Sport = new Sport() { Id = 1 } });
                context.Bookings.Add(new Booking() { Id = 1, BookingDate = new DateTime(2019, 10, 10, 10, 0, 0), CourtForeignKey = 1, MemberForeignKey = 1 });
                context.Bookings.Add(new Booking() { Id = 2, BookingDate = new DateTime(2019, 10, 10, 11, 0, 0), CourtForeignKey = 1, MemberForeignKey = 1 });
                context.Bookings.Add(new Booking() { Id = 3, BookingDate = new DateTime(2019, 10, 10, 12, 0, 0), CourtForeignKey = 1, MemberForeignKey = 1 });
                context.SaveChanges();
            }

            // Checks if the user is allowed to perform the booking
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);

                var exists = manager.BookingMemberAllowed(1, new DateTime(2019, 10, 10, 14, 0, 0));
                exists.Should().BeFalse();
            }
        }

        [TestMethod]
        public void BookingMemberNotAllowedSameTimeTest()
        {
            var options = new DbContextOptionsBuilder<SportCenterDBContext>()
                            .UseInMemoryDatabase(databaseName: "BookingManager_BookingMemberNotAllowedSameTimeTest")
                            .Options;

            // Add the elements
            using (var context = new SportCenterDBContext(options))
            {
                context.Members.Add(new Member() { Id = 1 });
                context.Courts.Add(new Court() { Id = 1, Sport = new Sport() { Id = 1 } });
                context.Bookings.Add(new Booking() { Id = 1, BookingDate = new DateTime(2019, 10, 10, 10, 0, 0), CourtForeignKey = 1, MemberForeignKey = 1 });
                context.SaveChanges();
            }

            // Checks if the user is allowed to perform the booking
            using (var context = new SportCenterDBContext(options))
            {
                var manager = new BookingManager(context);

                var exists = manager.BookingMemberAllowed(1, new DateTime(2019, 10, 10, 10, 0, 0));
                exists.Should().BeFalse();
            }
        }
    }    
}
