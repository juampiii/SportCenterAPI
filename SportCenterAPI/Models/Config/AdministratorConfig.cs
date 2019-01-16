using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportCenterAPI.Models.Config
{
    /// <summary>
    /// The <see cref="Administrator"/> model configuration
    /// </summary>
    public class AdministratorConfig
    {
        /// <summary>
        /// Configure the <see cref="Administrator"/> properties
        /// </summary>
        /// <param name="builder">The entity builder to model the admin properties</param>
        public static void SetBuilder(EntityTypeBuilder<Administrator> builder)
        {
        }
    }
}
