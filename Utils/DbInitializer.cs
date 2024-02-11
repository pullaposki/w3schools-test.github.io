using WebApi.Data;
using WebApi.Models;

namespace WebApi.Utils
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if the database has been seeded already
            if (HasDbBeenSeeded(context))
            {
                return;
            }

            SeedDb(context);
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

        public static bool HasDbBeenSeeded(ApplicationDbContext context) => context.Companies.Any() || context.PriceCategories.Any() || context.ShipRates.Any();
    }
}