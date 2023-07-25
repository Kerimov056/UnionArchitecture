﻿//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using UnionArchitecture.Aplication.Abstraction.Services;
//using UnionArchitecture.Domain.Entities;
//using UnionArchitecture.Domain.Entities.Identity;

//namespace UnionArchitecture.Persistence.Implementations.Services;

//public class GenerateToken : IGenerateToken
//{
//    private readonly IConfiguration _configuration;
//    public GenerateToken(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public string GenerateAccessToken(AppUser user)
//    {
//        List<Claim> claims = new List<Claim>
//        {
//                new Claim(ClaimTypes.Name,user.UserName),
//                new Claim(ClaimTypes.NameIdentifier,user.Id),
//                new Claim(ClaimTypes.Email,user.Email),
//        };
//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:key").Value));

//        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

//        var token = new JwtSecurityToken(
//            claims: claims,
//            expires: DateTime.Now.AddHours(2),
//            signingCredentials: cred);

//        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
//        return jwt;
//    }

//    public RefreshToken GenerateRefreshToken()
//    {
//        var refreshToken = new RefreshToken
//        {
//            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
//            Expires = DateTime.Now.AddDays(7),
//            Created = DateTime.Now
//        };
//        return refreshToken;
//    }

//    public async Task SetRefreshToken(RefreshToken newRefreshToken, HttpResponse Response)
//    {
//        var cookie = new CookieOptions
//        {
//            HttpOnly = true,
//            Expires = newRefreshToken.Expires
//        };
//        Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookie);
//    }
//}
