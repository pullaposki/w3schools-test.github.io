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
            var priceCategory1 = new PriceCategory 
            {   PriceCategoryName = "Category 1" };

            var priceCategory2 = new PriceCategory 
            {   PriceCategoryName = "Category 2" };

            var priceCategory3 = new PriceCategory 
            {   PriceCategoryName = "Category 3" };
            

            var companyA = new Company { 
                CompanyName = "Company A",
                PriceCategoryId = priceCategory1.PriceCategoryId,
                ShipRates = new List<ShipRate>
                {
                    new ShipRate { 
                        PerKg = 10.00m,
                        PerCubicMeter = 20.00m,
                        PerKm = 30.00m
                     },
                    new ShipRate { 
                        PerKg = 40.00m,
                        PerCubicMeter = 50.00m,
                        PerKm = 60.00m
                     },
                     new ShipRate { 
                        PerKg = 70.00m,
                        PerCubicMeter = 80.00m,
                        PerKm = 90.00m
                     }                     
                }
            };

            var companyB = new Company { 
                CompanyName = "Company B",
                PriceCategoryId = priceCategory2.PriceCategoryId,
                ShipRates = new List<ShipRate>
                {
                    new ShipRate { 
                        PerKg = 100.00m,
                        PerCubicMeter = 200.00m,
                        PerKm = 300.00m
                     },
                    new ShipRate { 
                        PerKg = 400.00m,
                        PerCubicMeter = 500.00m,
                        PerKm = 600.00m
                     },
                     new ShipRate { 
                        PerKg = 700.00m,
                        PerCubicMeter = 800.00m,
                        PerKm = 900.00m
                     }                     
                }
            };

            var companyC = new Company { 
                CompanyName = "Company C",
                PriceCategoryId = priceCategory3.PriceCategoryId,
                ShipRates = new List<ShipRate>
                {
                    new ShipRate { 
                        PerKg = 1000.00m,
                        PerCubicMeter = 2000.00m,
                        PerKm = 3000.00m
                     },
                    new ShipRate { 
                        PerKg = 4000.00m,
                        PerCubicMeter = 5000.00m,
                        PerKm = 6000.00m
                     },
                     new ShipRate { 
                        PerKg = 7000.00m,
                        PerCubicMeter = 8000.00m,
                        PerKm = 9000.00m
                     }                     
                }
            };
        }

        private static bool HasDbBeenSeeded(ApplicationDbContext context) => context.Companies.Any() || context.PriceCategories.Any() || context.ShipRates.Any();
    }
}