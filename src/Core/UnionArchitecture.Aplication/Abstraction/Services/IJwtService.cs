using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IJwtService
{
    TokenResponseDTO CreateJwtToken(AppUser appUser);
}
