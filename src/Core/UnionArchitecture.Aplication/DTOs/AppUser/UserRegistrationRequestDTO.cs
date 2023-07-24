using System.ComponentModel.DataAnnotations;

namespace UnionArchitecture.Aplication.DTOs.AppUser;

public class UserRegistrationRequestDTO
{

    public string? Fullname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
