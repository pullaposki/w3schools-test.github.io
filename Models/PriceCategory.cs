namespace WebApi.Models
{
    public class PriceCategory
    {
        public int PriceCategoryId { get; set; }
        
        // Foreign key for ShipRate
        public int ShipRateId { get; set; }

        // Navigation property for ShipRate
        public ShipRate ShipRate { get; set; } = new ShipRate();
    }
}