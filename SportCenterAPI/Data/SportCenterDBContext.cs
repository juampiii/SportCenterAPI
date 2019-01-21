using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Models;
using SportCenterAPI.Models.Config;

namespace SportCenterAPI.Data
{
    /// <summary>
    /// <see cref="DbContext"/> implementation fot the Sport Center
    /// </summary>
    public class SportCenterDBContext : DbContext
    {
        /// <summary>
        /// The list of <see cref="Sport"/> entities loaded from the database
        /// </summary>
        public DbSet<Sport> Sports { get; set; }

        /// <summary>
        /// The list of <see cref="Court"/> entities loaded from the database
        /// </summary>
        
        public DbSet<Court> Courts { get; set; }

        /// <summary>
        /// The list of <see cref="Booking"/> entities loaded from the database
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// The list of <see cref="Member"/> entities loaded from the database
        /// </summary>
        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// The list of <see cref="User"/> entities loaded from the database
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Initializes a new intance of the a <see cref="SportCenterDBContext"/>
        /// </summary>
        public SportCenterDBContext()
        {
        }

        /// <summary>
        /// Initializes a new intance of the a <see cref="SportCenterDBContext"/>
        /// </summary>
        /// <param name="options">The options used by the <see cref="SportCenterDBContext"/></param>
        public SportCenterDBContext(DbContextOptions<SportCenterDBContext> options)
                            : base(options)
        {
        }

        /// <summary>
        /// Allow to configure the model before it is blocked.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BookingConfig.SetBuilder(modelBuilder.Entity<Booking>());
            CourtConfig.SetBuilder(modelBuilder.Entity<Court>());
            MemberConfig.SetBuilder(modelBuilder.Entity<Member>());
            SportConfig.SetBuilder(modelBuilder.Entity<Sport>());
            UserConfig.SetBuilder(modelBuilder.Entity<User>());

            ModelBuilderExtensions.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
