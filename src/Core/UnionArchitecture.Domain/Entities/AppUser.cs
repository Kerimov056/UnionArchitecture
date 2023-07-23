using Microsoft.AspNetCore.Identity;

namespace UnionArchitecture.Domain.Entities;

public class AppUser:IdentityUser
{
    public string? FullName { get; set; }    
}
