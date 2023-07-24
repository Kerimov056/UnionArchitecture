using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Auth;
using UnionArchitecture.Domain.Entities.Identity;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class IAuthServic : IAuthService
{
    public Task Register(RegisterDTO registerDTO)
    {
        AppUser user = new()
        {

        };
    }
}
