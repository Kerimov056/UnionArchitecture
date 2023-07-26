using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Auth;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO requestDTO)
    {
        await _authService.Register(requestDTO);
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var responseToken = await _authService.Login(loginDTO);
        return Ok(responseToken);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> RefreshToken([FromQuery] string Refreshtoken)
    {
        var response = await _authService.ValidRefleshToken(Refreshtoken);
        return Ok(response);
    }
}