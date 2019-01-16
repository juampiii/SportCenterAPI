using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Models;
using SportCenterAPI.Models.Config;

namespace SportCenterAPI.Data
{
    public class SportCenterDBContext : DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Court> Courts { get; set; }

        public SportCenterDBContext(DbContextOptions<SportCenterDBContext> options)
                            : base(options)
        {

        }

        public SportCenterDBContext()
        {

        }

        /// <summary>
        /// Allow to configure the model before it is blocked.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AdministratorConfig.SetBuilder(modelBuilder.Entity<Administrator>());
            BookingConfig.SetBuilder(modelBuilder.Entity<Booking>());
            CourtConfig.SetBuilder(modelBuilder.Entity<Court>());
            MemberConfig.SetBuilder(modelBuilder.Entity<Member>());
            SportConfig.SetBuilder(modelBuilder.Entity<Sport>());
            UserConfig.SetBuilder(modelBuilder.Entity<User>());
        }
    }
}
