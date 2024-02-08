namespace WebApi.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        
        // FK to PriceCategoryConfig
        public int PriceCategoryId  { get; set; } 
        
        // Navigation properties
        public PriceCategory PriceCategory {get; set; } = new PriceCategory();
        public List<ShipRate> ShipRates { get; set; } = [];
    }
}