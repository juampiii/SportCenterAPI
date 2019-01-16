using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportCenterAPI.Models.Config
{
    /// <summary>
    /// The <see cref="Sport"/> model configuration
    /// </summary>
    public class SportConfig
    {
        /// <summary>
        /// Configure the <see cref="Sport"/> properties
        /// </summary>
        /// <param name="builder">The entity builder to model the sport properties</param>
        public static void SetBuilder(EntityTypeBuilder<Sport> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired();
            builder.HasMany(s => s.Courts).WithOne();
        }
    }
}
