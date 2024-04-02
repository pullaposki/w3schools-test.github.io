using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("PriceCategories")]
    public class PriceCategory
    {
        public int PriceCategoryId { get; set; }

        public string PriceCategoryName { get; set; } = string.Empty;

        // Foreign key for ShipRates
        public int ShipRatesId { get; set; }

        // Navigation property for ShipRates lookup table
        public ShipRates? ShipRates { get; set; }
    }
}