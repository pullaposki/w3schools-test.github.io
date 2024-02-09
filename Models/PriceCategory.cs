namespace WebApi.Models
{
    public class PriceCategory
    {
        public int PriceCategoryId { get; set; }

        public string PriceCategoryName { get; set; } = string.Empty;
        
        // Foreign key for ShipRate
        public int ShipRateId { get; set; }

        // Navigation property for ShipRate
        public ShipRate ShipRate { get; set; } = new ShipRate();
    }
}