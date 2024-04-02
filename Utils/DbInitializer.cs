using WebApi.Data;
using WebApi.Models;

namespace WebApi.Utils
{
    public class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (HasDbBeenSeeded(context)) return;

            SeedDb(context);
            SeedAppUserCompanies(context);
            SeedEmployees(context);
        }

        private static void SeedDb(ApplicationDbContext context)
        {
            var priceCategories = new PriceCategory[]
            {
                new PriceCategory { PriceCategoryName = "Category 1", ShipRates = new ShipRates { PerKg = 10, PerCubicMeter = 20, PerKm = 30 } },
                new PriceCategory { PriceCategoryName = "Category 2", ShipRates = new ShipRates { PerKg = 15, PerCubicMeter = 25, PerKm = 35 } },
                new PriceCategory { PriceCategoryName = "Category 3", ShipRates = new ShipRates { PerKg = 20, PerCubicMeter = 30, PerKm = 40 } }
            };
            context.PriceCategories.AddRange(priceCategories);

            var companies = new Company[]
            {
                new Company { CompanyName = "Company 1", PriceCategory = priceCategories.Single(pc => pc.PriceCategoryName == "Category 1") },

                new Company { CompanyName = "Company 2", PriceCategory = priceCategories.Single(pc => pc.PriceCategoryName == "Category 2") },

                new Company { CompanyName = "Company 3", PriceCategory = priceCategories.Single(pc => pc.PriceCategoryName == "Category 3") }
            };
            context.Companies.AddRange(companies);
            


            context.SaveChanges();
        }
        
        private static void SeedAppUserCompanies(ApplicationDbContext context)
        {
            // Check if there are any app user companies already
            if (context.AppUserCompanies.Any())
            {
                return;   // DB has been seeded
            }

            var appUserCompanies = new AppUserCompany[]
            {
                new AppUserCompany { AppUserId = "1", CompanyId = 1 },
                new AppUserCompany { AppUserId = "1", CompanyId = 2 },
                new AppUserCompany { AppUserId = "2", CompanyId = 2 },
                new AppUserCompany { AppUserId = "2", CompanyId = 3 },
                new AppUserCompany { AppUserId = "3", CompanyId = 3 },
            };

            foreach (AppUserCompany appUserCompany in appUserCompanies)
            {
                context.AppUserCompanies.Add(appUserCompany);
            }

            context.SaveChanges();
        }

        private static void SeedEmployees(ApplicationDbContext context)
        {
            // Check if there are any employees already
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee { FirstName = "John", LastName = "Doe", Position = "Manager", CompanyId = 1 },
                new Employee { FirstName = "Jane", LastName = "Doe", Position = "Developer", CompanyId = 1 },
                new Employee { FirstName = "Alice", LastName = "Smith", Position = "Manager", CompanyId = 2 },
                new Employee { FirstName = "Bob", LastName = "Johnson", Position = "Developer", CompanyId = 2 },
                new Employee { FirstName = "Charlie", LastName = "Williams", Position = "Manager", CompanyId = 3 },
                new Employee { FirstName = "David", LastName = "Brown", Position = "Developer", CompanyId = 3 },
            };

            foreach (Employee employee in employees)
            {
                context.Employees.Add(employee);
            }

            context.SaveChanges();
        }

        public static bool HasDbBeenSeeded(ApplicationDbContext context) => context.Companies.Any() || context.PriceCategories.Any() || context.ShipRates.Any();
    }
}