using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IIdentityService _identityService { get; set; }

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequestModel model)
        {
            var resp = await _identityService.SignInAsync(model);
            return Ok(resp);
        }
    }
}