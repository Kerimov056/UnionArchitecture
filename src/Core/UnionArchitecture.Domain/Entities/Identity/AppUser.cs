using Microsoft.AspNetCore.Identity;

namespace UnionArchitecture.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public bool IsActive { get; set; }
    public string? FullName { get; set; }
}
