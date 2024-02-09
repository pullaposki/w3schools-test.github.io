using WebApi.Models;

namespace WebApi.Dtos.Company
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public int PriceCategoryId { get; set; }
    }
}