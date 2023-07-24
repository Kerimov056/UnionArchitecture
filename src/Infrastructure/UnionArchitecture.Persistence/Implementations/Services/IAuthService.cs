using Microsoft.AspNetCore.Identity;
using System.Text;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class IAuthServic : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    public IAuthServic(UserManager<AppUser> userManager) => _userManager = userManager;
    public async Task Register(RegisterDTO registerDTO)
    {
        AppUser user = new()
        {
            FullName = registerDTO.Fullname,
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
            IsActive = false
        };

        IdentityResult identityUser = await _userManager.CreateAsync(user, registerDTO.password);
        if (!identityUser.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in identityUser.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }
    }
}
