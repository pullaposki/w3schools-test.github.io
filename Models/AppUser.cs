using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser
    {
        public List<AppUserCompany> AppUserCompanies { get; set; } = new List<AppUserCompany>();
    }
}