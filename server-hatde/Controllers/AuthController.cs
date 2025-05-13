using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_hatde.Requests;
using server_hatde.Services;

namespace server_hatde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var res = await _authService.LoginAsync(request);
            if (res == null)
            {
                return BadRequest("Vui lòng kiểm tra email hoặc mật khẩu");
            }
            return Ok(res);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            if (await _authService.ExistEmail(request.Email))
            {
                return BadRequest("Email đã được sử dụng");
            }
            if (await _authService.ExistPhone(request.Phone))
            {
                return BadRequest("Phone đã được sử dụng");
            }
            var isRegister  = await _authService.RegisterAsync(request);
            return isRegister ? Ok() : BadRequest("Không thể đăng ký người dùng, vui lòng xem lại."); 
        }
    }
}
