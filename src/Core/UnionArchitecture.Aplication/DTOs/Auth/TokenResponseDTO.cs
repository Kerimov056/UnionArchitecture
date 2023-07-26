namespace UnionArchitecture.Aplication.DTOs.Auth;
    public record TokenResponseDTO(string token,
                                   DateTime expireDate,
                                   DateTime refreshTokenExpration,
                                   string refreshToken);