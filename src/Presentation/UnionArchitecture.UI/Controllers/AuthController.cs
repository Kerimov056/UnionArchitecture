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
    public async Task<ActionResult> Register([FromBody] RegisterDTO requestDTO)
    {
        await _authService.Register(requestDTO);
        return Ok();
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        var responseToken = _authService.Login(loginDTO);
        return Ok(responseToken);
    }














    //private readonly UserManager<AppUser> _userManager;
    //private readonly IConfiguration _configuration;
    ////private readonly JwtConfig _jwtConfig;
    //public AccountController(UserManager<AppUser> userManager, IConfiguration configuration)
    //{
    //    _userManager = userManager;
    //    _configuration = configuration;
    //    //_jwtConfig = jwtConfig;
    //}

    //[HttpPost("register")]
    //public async Task<ActionResult> Register([FromBody] UserRegistrationRequestDTO requestDTO)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user_exist = await _userManager.FindByEmailAsync(requestDTO.Email);
    //        if (user_exist != null)
    //        {
    //            return BadRequest(error: new AuthResult()
    //            {
    //                Result = false,
    //                Errors = new List<string>()
    //                {
    //                    "Email already exist"
    //                }
    //            });
    //        }

    //        var new_user = new AppUser()
    //        {
    //            FullName = requestDTO.Fullname,
    //            Email = requestDTO.Email,
    //            UserName = requestDTO.Username   //ferqqqqqq
    //        };

    //        var is_created = await _userManager.CreateAsync(new_user, requestDTO.Password);

    //        if (is_created.Succeeded)
    //        {
    //            var token = GenerateJwtToken(new_user);

    //            return Ok(new AuthResult()
    //            {
    //                Result = true,
    //                Token = token
    //            });
    //        }

    //        return BadRequest(error: new AuthResult()
    //        {
    //            Errors = new List<string>()
    //            {
    //                "Server error"
    //            },
    //            Result = false
    //        });
    //    }

    //    return BadRequest();
    //}


    //private string GenerateJwtToken(AppUser user)
    //{
    //    var JwtTokenHandler = new JwtSecurityTokenHandler();

    //    var key = Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

    //    var tokenDescriptor = new SecurityTokenDescriptor()
    //    {
    //        Subject = new ClaimsIdentity(new[]
    //        {
    //            new Claim(type:"Id",value:user.Id),
    //            new Claim(type:JwtRegisteredClaimNames.Sub,value:user.Email),
    //            new Claim(type:JwtRegisteredClaimNames.Email,value:user.Email),
    //            new Claim(type:JwtRegisteredClaimNames.Jti,value:Guid.NewGuid().ToString()),
    //            new Claim(type:JwtRegisteredClaimNames.Iat,value:DateTime.Now.ToUniversalTime().ToString())

    //        }),

    //        Expires = DateTime.Now.AddHours(1),
    //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256)
    //    };

    //    var token = JwtTokenHandler.CreateToken(tokenDescriptor);
    //    var jwtToken = JwtTokenHandler.WriteToken(token);

    //    return jwtToken;
    //}


    //[HttpPost("login")]
    //public ActionResult<AppUser> Login(UserCreateDTO userCreateDTO)
    //{
    //    if (user.UserName != userCreateDTO.Username)
    //    {
    //        return BadRequest("User not found");
    //    }

    //    if (!BCrypt.Net.BCrypt.Verify(userCreateDTO.Password, user.PasswordHash))
    //    {
    //        return BadRequest("Wrong password");
    //    }

    //    return Ok();
    //}
}