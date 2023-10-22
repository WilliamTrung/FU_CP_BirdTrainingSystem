using AppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthModels;

namespace BirdTrainingCenterAPI.Controllers.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {
            try
            {
                var token = await _authService.Login(loginModel);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequestModel registerModel)
        {
            try
            {
                var token = await _authService.Register(registerModel);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
