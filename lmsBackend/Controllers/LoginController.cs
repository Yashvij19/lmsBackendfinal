using Microsoft.AspNetCore.Mvc;
using lmsBackend.Repository.LoginRepo;
using lmsBackend.Dtos.LoginDtos;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILogin _loginService;

    public LoginController(ILogin loginService)
    {
        _loginService = loginService;
    }

    // Login Endpoint - Returns true if successful, false otherwise
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        bool isLoggedIn = await _loginService.Login(loginDto.Email, loginDto.Password);

        return isLoggedIn ? Ok(true) : BadRequest(false);
    }

}