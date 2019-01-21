using System;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Models;

namespace SportCenterAPI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Represents an extension to seed the database with data
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport { Id = 1, Name = "Padel" },
                new Sport { Id = 2, Name = "Futbol" }
            );
            modelBuilder.Entity<Court>().HasData(
                new Court { Id = 1, Name = "Padel Court 1", SportForeignKey = 1 },
                new Court { Id = 2, Name = "Padel Court 2", SportForeignKey = 1 },
                new Court { Id = 3, Name = "Futbol Court 1", SportForeignKey = 2 },
                new Court { Id = 4, Name = "Futbol Court 2", SportForeignKey = 2 }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Password = "12341234" },
                new User { Id = 2, Name = "User1", Password = "12341234" }
            );
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 2, Name = "Member1", Phone = "676789098" },
                new Member { Id = 3, Name = "Member2", Phone = "676789098" }
            );
            modelBuilder.Entity<Booking>().HasData(
                new Booking() { Id = 1, MemberForeignKey = 2, CourtForeignKey = 2, BookingDate = new System.DateTime(2019, 01, 17, 14, 0, 0), CreatedDate = DateTime.Now },
                new Booking() { Id = 2, MemberForeignKey = 3, CourtForeignKey = 3, BookingDate = new System.DateTime(2019, 01, 17, 21, 0, 0), CreatedDate = DateTime.Now }
                );
        }
    }
}
