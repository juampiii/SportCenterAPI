using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportCenterAPI.Models.Config
{
    /// <summary>
    /// The <see cref="Booking"/> model configuration
    /// </summary>
    public class BookingConfig
    {
        /// <summary>
        /// Configure the <see cref="Booking"/> properties
        /// </summary>
        /// <param name="builder">The entity builder to model the booking properties</param>
        public static void SetBuilder(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.HasAlternateKey(b => new { b.CourtForeignKey, b.MemberForeignKey, b.BookingDate });
            builder.HasOne(b => b.Member).WithMany(m => m.Bookings).HasForeignKey(b => b.MemberForeignKey);
            builder.HasOne(b => b.Court).WithMany(c => c.Bookings).HasForeignKey(b => b.CourtForeignKey);
        }
    }
}
