using CarRepairService.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairService.DataBase
{
    public class CRSContext : DbContext
    {
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Document>? Dpcuments { get; set; }
        public DbSet<Worker>? Workers { get; set; }
        public CRSContext(DbContextOptions<CRSContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
