using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Domain.Enums;
using UnionArchitecture.Persistence.Exceptions;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class AuthServic : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _siginManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IJwtService _jwtService;

    public AuthServic(UserManager<AppUser> userManager,
                      SignInManager<AppUser> siginManager,
                      RoleManager<IdentityRole> roleManager,
                      IConfiguration configuration,
                      IJwtService jwtService)
    {
        _userManager = userManager;
        _siginManager = siginManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _jwtService = jwtService;
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

        SignInResult signResult = await _siginManager.CheckPasswordSignInAsync(appUser, loginDTO.password, true);
        if (!signResult.Succeeded)
        {
            throw new LogInFailerException("Invalid Login!");
        }
        //if (!appUser.IsActive)
        //{
        //    throw new Exception("User is inactive. Please contact support.");
        //}




        TokenResponseDTO token = _jwtService.CreateJwtToken(appUser);
        return token;

        //List<Claim> claims = new List<Claim>()
        //{
        //    new Claim(ClaimTypes.NameIdentifier,appUser.Id),
        //    new Claim(ClaimTypes.Email,appUser.Email),
        //};

        //var roles = await _userManager.GetRolesAsync(appUser);
        //foreach (var role in roles)
        //{
        //    claims.Add(new Claim(ClaimTypes.Role, role));
        //}

        //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        //SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
        //JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
        //    issuer: _configuration["JwtSettings:Issues"],
        //    audience: _configuration["JwtSettings:Audience"],
        //    claims:claims,
        //    notBefore: DateTime.UtcNow,
        //    expires: DateTime.UtcNow.AddMinutes(1),
        //    signingCredentials:signingCredentials
        //    );

        //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //var token = handler.WriteToken(jwtSecurityToken);

        //return new TokenResponseDTO(token, jwtSecurityToken.ValidTo);
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

