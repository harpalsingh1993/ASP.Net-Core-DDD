using Microsoft.EntityFrameworkCore;

namespace CoreAuthentication.DataAccess
{
    public class AEContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AEContext(DbContextOptions<AEContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
