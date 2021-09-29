using Microsoft.EntityFrameworkCore;
using SDE_Server.Entities;

namespace SDE_Server.Infrastructure
{
    public class SDEDBContext : DbContext
    {
        public SDEDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SDEDBContext).Assembly);
    }
}
