namespace WebApi.Models
{
    public class PriceCategory
    {
        public int PriceCategoryId { get; set; }
        public string PriceCategoryName { get; set; } = string.Empty;
        
        // Navigation property
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}