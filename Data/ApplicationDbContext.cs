using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<PriceCategory> PriceCategories { get; set; }
        public DbSet<ShipRates> ShipRates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUserCompany> AppUserCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set up many-to-many relationship between AppUser and Company
            // This is done by creating a new entity called AppUserCompany
            // with two foreign keys: AppUserId and CompanyId
            // The primary key is a combination of the two foreign keys
            modelBuilder.Entity<AppUserCompany>(entityTypeBuilder => entityTypeBuilder
                .HasKey(appUserCompany => new { appUserCompany.AppUserId, appUserCompany.CompanyId }));
            
            modelBuilder.Entity<AppUserCompany>()
                .HasOne(appUserCompany => appUserCompany.AppUser) // This specifies that the AppUserCompany entity has a single AppUser. This sets up one side of a one-to-many relationship.
                .WithMany(appUser => appUser.AppUserCompanies) // This specifies that the AppUser entity has many AppUserCompany entities. This sets up the other side of the one-to-many relationship.
                .HasForeignKey(appUserCompany => appUserCompany.AppUserId); // This specifies that the AppUserId property on the AppUserCompany entity is the foreign key for this relationship.
            
            modelBuilder.Entity<AppUserCompany>()
                .HasOne(appUserCompany => appUserCompany.Company) // This specifies that the AppUserCompany entity has a single Company. This sets up one side of a one-to-many relationship.
                .WithMany(company => company.AppUserCompanies) // This specifies that the Company entity has many AppUserCompany entities. This sets up the other side of the one-to-many relationship.
                .HasForeignKey(appUserCompany => appUserCompany.CompanyId); // This specifies that the CompanyId property on the AppUserCompany entity is the foreign key for this relationship.

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            modelBuilder.Entity<IdentityRole>()
                .HasData(roles);
        }
    }
}