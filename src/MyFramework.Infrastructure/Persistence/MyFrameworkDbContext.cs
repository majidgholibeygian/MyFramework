using Microsoft.EntityFrameworkCore;
using MyFramework.Domain.Entities;

namespace MyFramework.Infrastructure.Persistence
{
    public class MyFrameworkDbContext : DbContext
    {
        public MyFrameworkDbContext(DbContextOptions<MyFrameworkDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
                b.Property(x => x.LastName).HasMaxLength(100).IsRequired();
                b.Property(x => x.Email).HasMaxLength(256).IsRequired();
                b.Property(x => x.DateOfBirth).IsRequired();
            });
        }
    }
}
