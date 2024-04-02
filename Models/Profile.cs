using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

[Table("Profiles")]
public class Profile
{
    // Primary key
    [Key] public string Id { get; set; }

    // Foreign key for AppUser
    public string AppUserId { get; set; }

    // Navigation property for AppUser
    public AppUser AppUser { get; set; }

    // Other properties for Profile
    public string Bio { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
}