using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<PriceCategory> PriceCategories { get; set; }
        public DbSet<ShipRate> ShipRates { get; set; }
    }
}