﻿using Microsoft.AspNetCore.Http;
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
using UnionArchitecture.Persistence.Contexts;
using UnionArchitecture.Persistence.Exceptions;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class AuthServic : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _siginManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _configuration;
    private readonly ITokenHandler _tokenHandler;

    public AuthServic(UserManager<AppUser> userManager,
                      SignInManager<AppUser> siginManager,
                      RoleManager<IdentityRole> roleManager,
                      AppDbContext appDbContext,
                      IConfiguration configuration,
                      ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _siginManager = siginManager;
        _roleManager = roleManager;
        _appDbContext = appDbContext;
        _configuration = configuration;
        _tokenHandler = tokenHandler;
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
        //    throw new UserBlockedException("User Blocked");
        //}
        var tokenResponse = await _tokenHandler.CreateAccessToken(2,3,appUser);
        appUser.RefreshToken = tokenResponse.refreshToken;
        appUser.RefreshTokenExpration = tokenResponse.refreshTokenExpration;
        await _userManager.UpdateAsync(appUser);
        return tokenResponse;
    }

    
    public async Task<TokenResponseDTO> ValidRefleshToken(string refreshToken)
    {
        if (refreshToken is null)
        {
            throw new ArgumentNullException("Refresh token does not exist");
        }
        var appUser = await _appDbContext.Users.Where(a => a.RefreshToken == refreshToken).FirstOrDefaultAsync();
        if (appUser is null)
        {
           throw new NotFoundException("User does Not Exist");
        }
        if (appUser.RefreshTokenExpration < DateTime.UtcNow)
        {
            throw new ArgumentNullException("Refresh token does not exist");
        }

        var tokenResponse = await _tokenHandler.CreateAccessToken(2,3, appUser);
        appUser.RefreshToken = tokenResponse.refreshToken;
        appUser.RefreshTokenExpration = tokenResponse.refreshTokenExpration;
        await _userManager.UpdateAsync(appUser);
        return tokenResponse;
    }
}

