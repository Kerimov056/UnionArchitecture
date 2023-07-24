using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public TokenResponseDTO CreateJwtToken(AppUser appUser)
    {
        DateTime dateTime  = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:EXPIRATION_MINUTES"]));
        Claim[] claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, appUser.Id.ToString()),

            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

            new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),

            new Claim(ClaimTypes.NameIdentifier,appUser.Email.ToString()),
        };

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JwtSettings:key"]));

        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            _configuration["JwtSettings:Issues"],
            _configuration["JwtSettings:Audience"],
            claims,
            expires: dateTime,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        string token = tokenHandler.WriteToken(jwtSecurityToken);

        return new TokenResponseDTO(token, dateTime);
    }
}


