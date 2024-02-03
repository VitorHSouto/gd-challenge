using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Dtos.Address
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
