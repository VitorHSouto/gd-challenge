using gd_api.Domain.Dtos.Company;
using gd_api.Domain.Dtos.File;
using gd_api.Domain.Dtos.Product;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly FileService _fileService;
        public ProductService(
            ProductRepository productRepository,
            FileService fileService
            )
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<List<ProductDTO>> ListByCompanyId(Guid companyId, ProductIncludeDetails includeDetails)
        {   
            var entities = await _productRepository.ListByCompanyId(companyId);
            return await ToDTO(entities, includeDetails);
        }

        private async Task<List<ProductDTO>> ToDTO(List<ProductEntity> entities, ProductIncludeDetails details = ProductIncludeDetails.Undefined)
        {
            var dtos = new List<ProductDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(await ToDTO(entity, details));
            }
            return dtos;
        }

        private async Task<ProductDTO> ToDTO(ProductEntity entity, ProductIncludeDetails details)
        {
            var dto = new ProductDTO();
            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            dto.Active = entity.Active;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Price = entity.Price;
            dto.CompanyId = entity.CompanyId;
            dto.FileIds = entity.FileIds.ToList();

            if (details.HasFlag(ProductIncludeDetails.All) || details.HasFlag(ProductIncludeDetails.File))
            {
                dto.Files = new List<FileDTO>();
                foreach (var id in entity.FileIds)
                {
                    var file = await _fileService.GetById(id);
                    dto.Files.Add(file);
                }
            }

            return dto;
        }
    }
}
