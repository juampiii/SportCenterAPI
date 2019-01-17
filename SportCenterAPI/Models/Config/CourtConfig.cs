using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportCenterAPI.Models.Config
{
    /// <summary>
    /// The <see cref="Court"/> model configuration
    /// </summary>
    public class CourtConfig
    {
        /// <summary>
        /// Configure the <see cref="Court"/> properties
        /// </summary>
        /// <param name="builder">The entity builder to model the court properties</param>
        public static void SetBuilder(EntityTypeBuilder<Court> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.HasOne(c => c.Sport).WithMany(s => s.Courts).HasForeignKey(c => c.SportForeignKey).IsRequired();
        }
    }
}
