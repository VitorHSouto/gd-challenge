using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Dtos.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
