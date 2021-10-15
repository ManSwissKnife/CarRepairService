using CarRepairService.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairService.Database
{
    public class CRSContext : DbContext
    {
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
        }
    }
}
