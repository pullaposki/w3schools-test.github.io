using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Companies")]
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        // Foreign key for PriceCategory
        public int PriceCategoryId { get; set; }

        // Navigation property for PriceCategory
        public PriceCategory PriceCategory { get; set; } = new PriceCategory();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<AppUserCompany> AppUserCompanies { get; set; } = new List<AppUserCompany>();
    }
}