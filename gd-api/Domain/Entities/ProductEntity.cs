using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("companyid")]
        public Guid CompanyId { get; set; }

        [Column("fileids")]
        public Guid[] FileIds { get; set; }
    }
}
