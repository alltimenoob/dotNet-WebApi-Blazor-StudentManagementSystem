using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace InfrastructureLayer.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Admin>()
                .WithOne()
                .HasForeignKey<Admin>(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne<Student>()
                .WithOne()
                .HasForeignKey<Student>(e => e.UserId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

    }
}
