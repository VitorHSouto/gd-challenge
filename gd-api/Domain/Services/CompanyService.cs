using gd_api.Domain.Dtos.Company;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace gd_api.Domain.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;
        private readonly AddressService _addressService;
        public CompanyService(
            CompanyRepository companyRepository,
            AddressService addressService
        )
        {
            _companyRepository = companyRepository;
            _addressService = addressService;
        }

        public async Task<List<CompanyDTO>> ListAll(CompanyFilterDTO filter)
        {
            var entities = await _companyRepository.ListAll();
            return await ToDTO(entities, filter.includeDetails);
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
