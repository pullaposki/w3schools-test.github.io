namespace WebApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        // Foreign key for Company
        public int CompanyId { get; set; }

        // Navigation property for Company
        public Company? Company { get; set; }
    }
}