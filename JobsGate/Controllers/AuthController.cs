using JobsGate.DTO.Accounts;
using JobsGate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                AuthResultDTO result =  await authService.Register(register);
                if (result.IsAuthenticated)
                    return Ok(result);
                return Unauthorized(result.Message);
            }
            return BadRequest(register);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthLoginDTO login)
        {
            if (ModelState.IsValid)
            {
                AuthResultDTO result = await authService.Login(login);
                if (result.IsAuthenticated)
                    return Ok(result);
                return Unauthorized(result.Message);
            }
            return BadRequest(login);
        }
    }
}
