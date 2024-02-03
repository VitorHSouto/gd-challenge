using gd_api.Domain.Dtos.Login;
using gd_api.Domain.Dtos.User;
using gd_api.Domain.Helpers;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class LoginService
    {
        private readonly UserService _userService;
        public LoginService(UserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthenticatedUserDTO> Authenticate(AuthenticateDTO eq)
        {
            var userEntity = await _userService.GetByLogin(eq.Email, eq.Password);

            return new AuthenticatedUserDTO()
            {
                UserId = userEntity.Id,
                User = userEntity,
                Token = TokenHelper.GenerateToken(eq.Email),
            };
        }
    }
}
