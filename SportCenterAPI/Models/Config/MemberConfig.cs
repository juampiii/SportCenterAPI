using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportCenterAPI.Models.Config
{
    /// <summary>
    /// The <see cref="Member"/> model configuration
    /// </summary>
    public class MemberConfig
    {
        /// <summary>
        /// Configure the <see cref="Member"/> properties
        /// </summary>
        /// <param name="builder">The entity builder to model the member properties</param>
        public static void SetBuilder(EntityTypeBuilder<Member> builder)
        {
            builder.HasMany(m => m.Bookings).WithOne();
        }
    }
}
