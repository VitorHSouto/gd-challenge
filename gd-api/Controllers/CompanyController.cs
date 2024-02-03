using gd_api.Domain.Dtos.User;
using gd_api.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace gd_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController
    {
        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Get()
        {
            return "ok";
        }
    }
}
