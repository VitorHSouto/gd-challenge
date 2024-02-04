using gd_api.Domain.Dtos.Company;
using gd_api.Domain.Dtos.Product;
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
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<CompanyDTO>> ListAll([FromQuery] CompanyFilterDTO filter)
        {
            return await _companyService.ListAll(filter);
        }

        [HttpGet("{id}/product")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<ProductDTO>> ListProducts(Guid id, [FromQuery] ProductFilterDTO filter)
        {
            return await _companyService.ListProducts(id, filter);
        }
    }
}
