using CarRepairService.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairService.Database
{
    public class CRSContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }
        public CRSContext(DbContextOptions<CRSContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Username);
            //modelBuilder.Entity<User>().OwnsOne(u => u.RefreshTokens);
        }
    }
}
