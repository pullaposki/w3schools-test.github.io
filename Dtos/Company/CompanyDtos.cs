namespace WebApi.Dtos.Company
{
    public class ACompanyResponseDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public int PriceCategoryId { get; set; }
    }

    public class ACreateCompanyRequestDto
    {
        public string CompanyName { get; set; } = string.Empty;

         public int PriceCategoryId { get; set; }
    }

    public class AnUpdateCompanyRequestDto
    {
        public string CompanyName { get; set; } = string.Empty;

         public int PriceCategoryId { get; set; }
    }
}