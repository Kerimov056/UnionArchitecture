﻿using UnionArchitecture.Aplication.DTOs.Auth;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IAuthService
{
    Task Register(RegisterDTO registerDTO);
    Task<TokenResponseDTO> Login(LoginDTO loginDTO);
    Task<TokenResponseDTO> ValidRefleshToken(string refreshToken);
}
