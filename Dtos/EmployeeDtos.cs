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
}