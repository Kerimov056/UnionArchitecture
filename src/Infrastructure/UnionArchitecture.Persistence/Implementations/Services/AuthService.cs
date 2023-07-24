using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Domain.Enums;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class AuthServic : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _siginManager;
    private readonly RoleManager<IdentityUser> _roleManager;
    public AuthServic(UserManager<AppUser> userManager,
                      SignInManager<AppUser> siginManager,
                      RoleManager<IdentityUser> roleManager)
    {
        _userManager = userManager;
        _siginManager = siginManager;
        _roleManager = roleManager;
    }

    public async Task<TokenResponseDTO> Login(LoginDTO loginDTO)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(loginDTO.UsernameOrEmail);
        if (appUser is null)
        {
            appUser = await _userManager.FindByNameAsync(loginDTO.UsernameOrEmail);
            if (appUser is null)
            {
                throw new LogInFailerException("Invalid Login!");
            }
        }

        Microsoft.AspNetCore.Identity.SignInResult signResult = await _siginManager.CheckPasswordSignInAsync(appUser, loginDTO.password, true);
        if (!signResult.Succeeded)
        {
            throw new LogInFailerException("Invalid Login!");
        }
        if (!appUser.IsActive)
        {
            throw new Exception();
        }
        return new TokenResponseDTO("",DateTime.Now);
    }

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

        var result = await _userManager.AddToRoleAsync(user, Role.Member.ToString());
        if (!result.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in result.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }
    }
}
