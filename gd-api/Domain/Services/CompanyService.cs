using gd_api.Domain.Dtos.Company;
using gd_api.Domain.Dtos.Product;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace gd_api.Domain.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;
        private readonly AddressService _addressService;
        private readonly ProductService _productService;
        public CompanyService(
            CompanyRepository companyRepository,
            AddressService addressService,
            ProductService productService
        )
        {
            _companyRepository = companyRepository;
            _addressService = addressService;
            _productService = productService;
        }

        public async Task<List<CompanyDTO>> ListAll(CompanyFilterDTO filter)
        {
            var entities = await _companyRepository.Filter(filter.searchText);
            return await ToDTO(entities, filter.includeDetails);
        }

        public async Task<List<ProductDTO>> ListProducts(Guid id, ProductFilterDTO filter)
        {
            return await _productService.ListByCompanyId(id);
        }

        private async Task<List<CompanyDTO>> ToDTO(List<CompanyEntity> entities, CompanyIncludeDetails details = CompanyIncludeDetails.Undefined)
        {
            var dtos = new List<CompanyDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(await ToDTO(entity, details));
            }
            return dtos;
        }

        private async Task<CompanyDTO> ToDTO(CompanyEntity entity, CompanyIncludeDetails details = CompanyIncludeDetails.Undefined)
        {
            var dto = new CompanyDTO();
            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            dto.Active = entity.Active;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Phone = entity.Phone;
            dto.AddressId = entity.AddressId;

            if(details.HasFlag(CompanyIncludeDetails.Address) || details.HasFlag(CompanyIncludeDetails.All))
            {
                dto.Address = await _addressService.GetById(entity.AddressId);
            }

            return dto;
        }
    }
}
