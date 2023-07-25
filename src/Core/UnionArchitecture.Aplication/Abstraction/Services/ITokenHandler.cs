using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ITokenHandler
{
    public Task<TokenResponseDTO> CreateAccessToken(int minutes,AppUser appUser);
}
