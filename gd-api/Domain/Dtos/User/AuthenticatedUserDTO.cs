using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Dtos.User
{
    public class AuthenticatedUserDTO
    {
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
