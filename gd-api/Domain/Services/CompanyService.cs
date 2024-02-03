using gd_api.Domain.Dtos.Company;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyDTO>> ListAll()
        {
            var entities = await _companyRepository.ListAll();
            return entities.Select(ToDTO).ToList();
        }

        private CompanyDTO ToDTO(CompanyEntity entity)
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

            return dto;
        }
    }
}
