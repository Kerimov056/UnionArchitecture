using Microsoft.AspNetCore.Identity;
using System.Data;

namespace UnionArchitecture.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public bool IsActive { get; set; }
    public string? FullName { get; set; }
    public DateTime RefreshTokenExpration { get; set; }
    public string? RefreshToken { get; set; } 
}
