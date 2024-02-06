using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Entities
{
    public class CompanyEntity : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("addressid")]
        public Guid AddressId { get; set; }

        [Column("bannerfileid")]
        public Guid? BannerFileId { get; set; }

        [Column("logofileid")]
        public Guid? LogoFileId { get; set; }
    }
}
