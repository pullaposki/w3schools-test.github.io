namespace WebApi.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        // Foreign key for PriceCategory
         public int PriceCategoryId { get; set; }

        // Navigation property for PriceCategory
        public PriceCategory PriceCategory {get; set; } = new PriceCategory();
    }
}