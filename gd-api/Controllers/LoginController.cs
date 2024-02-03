using gd_api.Domain.Dtos.Login;
using gd_api.Domain.Dtos.User;
using gd_api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace gd_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<AuthenticatedUserDTO> Authenticate(AuthenticateDTO req)
        {
            return await _loginService.Authenticate(req);
        }
    }
}
