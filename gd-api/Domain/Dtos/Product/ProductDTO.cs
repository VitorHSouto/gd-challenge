using gd_api.Domain.Dtos.File;
using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Dtos.Product
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CompanyId { get; set; }
        public List<Guid> FileIds { get; set; }
        public List<FileDTO> Files { get; set; }
    }
}
