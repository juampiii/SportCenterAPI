using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportCenterAPI.Models.Config
{
    /// <summary>
    /// The <see cref="User"/> model configuration
    /// </summary>
    public class UserConfig
    {
        /// <summary>
        /// Configure the <see cref="User"/> properties
        /// </summary>
        /// <param name="builder">The entity builder to model the user properties</param>
        public static void SetBuilder(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Password).IsRequired();
        }
    }
}
