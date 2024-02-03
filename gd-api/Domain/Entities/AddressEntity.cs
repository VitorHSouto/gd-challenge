using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Entities
{
    public class AddressEntity : EntityBase
    {
        [Column("street")]
        public string Street { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("zipcode")]
        public string ZipCode { get; set; }
    }
}
