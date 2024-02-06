using gd_api.Domain.Dtos.Company;
using gd_api.Domain.Dtos.Product;
using gd_api.Domain.Dtos.User;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;
using gd_api.Domain.Settings;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace gd_api.Domain.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;
        private readonly AddressService _addressService;
        private readonly ProductService _productService;
        private readonly FileService _fileService;
        public CompanyService(
            CompanyRepository companyRepository,
            AddressService addressService,
            FileService fileService,
            ProductService productService
        )
        {
            _companyRepository = companyRepository;
            _addressService = addressService;
            _productService = productService;
            _fileService = fileService;
        }

        public async Task<List<CompanyDTO>> ListAll(CompanyFilterDTO filter)
        {
            var entities = await _companyRepository.Filter(filter.searchText);
            return await ToDTO(entities, filter.includeDetails);
        }

        public async Task<CompanyDTO> GetById(Guid id)
        {
            var entity = await _companyRepository.GetById(id);
            if (entity == null)
                throw new CustomException("Empresa não encontrada.", CustomExceptionError.NotFound);

            return await ToDTO(entity, CompanyIncludeDetails.All);
        }

        public async Task<List<ProductDTO>> ListProducts(Guid id, ProductFilterDTO filter)
        {
            return await _productService.ListByCompanyId(id, filter.includeDetails);
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
            dto.BannerFileId = entity.BannerFileId;
            dto.LogoFileId = entity.LogoFileId;

            var includeAll = details.HasFlag(CompanyIncludeDetails.All);
            if (includeAll || details.HasFlag(CompanyIncludeDetails.Address))
            {
                dto.Address = await _addressService.GetById(entity.AddressId);
            }

            if (includeAll || details.HasFlag(CompanyIncludeDetails.File))
            {
                if(dto.BannerFileId.HasValue)
                    dto.BannerFile = await _fileService.GetById(entity.BannerFileId.Value);

                if (dto.LogoFileId.HasValue)
                    dto.LogoFile = await _fileService.GetById(entity.LogoFileId.Value);
            }

            return dto;
        }
    }
}
