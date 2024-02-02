using gd_api.Domain.Entities;
using gd_api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace gd_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("")]
        public async Task<List<UserEntity>> ListAll()
        {
            return await _userService.ListAll();
        }

        [HttpGet("{id}")]
        public async Task<UserEntity> Get(Guid id)
        {
            return await _userService.GetById(id);
        }
    }
}
