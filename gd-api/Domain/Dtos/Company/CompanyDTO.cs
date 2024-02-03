using gd_api.Domain.Dtos.Address;
using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Dtos.Company
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public Guid AddressId { get; set; }
        public AddressDTO? Address { get; set; }
    }
}
