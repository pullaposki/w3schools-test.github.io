using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    // Response
    public class ACompanyResponseDto
    {
        public int CompanyId { get; set; }

        
        public string CompanyName { get; set; } = string.Empty;

        public int PriceCategoryId { get; set; }
        public List<AnEmployeeResponseDto> Employees { get; set; } = new List<AnEmployeeResponseDto>();
    }

    // Request
    public class ACreateCompanyRequestDto
    {
        [Required, StringLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [Required, Range(1, int.MaxValue)]
        public int PriceCategoryId { get; set; }
    }

    public class AnUpdateCompanyRequestDto
    {
        public string CompanyName { get; set; } = string.Empty;

        public int PriceCategoryId { get; set; }
    }
}