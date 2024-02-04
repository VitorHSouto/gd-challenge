using gd_api.Domain.Dtos.Product;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> ListByCompanyId(Guid companyId)
        {
            var entities = await _productRepository.ListByCompanyId(companyId);
            return entities.Select(ToDTO).ToList();
        }

        private ProductDTO ToDTO(ProductEntity entity)
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
            return dto;
        }
    }
}
