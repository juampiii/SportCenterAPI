using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
