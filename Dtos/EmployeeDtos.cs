using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class AnEmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int CompanyId { get; set; }

    }

    public class ACreateEmployeeRequestDto
    {
        [Required, StringLength(200), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(200), MinLength(2)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(200), MinLength(1)]
        public string Position { get; set; } = string.Empty;
        //public int CompanyId { get; set; }
    }
    
    public class AnUpdateEmployeeRequestDto
    {
        [Required, StringLength(200), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(200), MinLength(2)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(200), MinLength(1)]
        public string Position { get; set; } = string.Empty;
    }
}