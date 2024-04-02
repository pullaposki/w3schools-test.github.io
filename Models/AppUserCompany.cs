using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

[Table("AppUserCompanies")]
public class AppUserCompany
{
    // Foreign keys
    public string AppUserId { get; set; }
    public int CompanyId { get; set; }
    
    // Navigation properties
    public AppUser AppUser { get; set; }
    public Company Company { get; set; }
}