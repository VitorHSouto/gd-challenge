using gd_api.Domain.Dtos.User;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        private JwtService _jwtService;
        public UserService(
            UserRepository userRepository,
            JwtService jwtService
        )
        {
            _userRepository = userRepository;
            _jwtService = jwtService;   
        }

        public async Task<List<UserDTO>> ListAll()
        {
            var entities = await _userRepository.ListAll();
            return entities.Select(ToDTO).ToList();
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var entity = await _userRepository.GetById(id);
            if (entity == null)
                throw new Exception("Usuário não encontrado.");

            return ToDTO(entity);
        }

        public async Task<UserDTO> Save(RequestSaveUserDTO req)
        {
            var entity = new UserEntity();
            entity.Email = req.Email;
            entity.Password = req.Password; //TODO: Adicionar hash

            await _userRepository.Save(entity);
            var dto = ToDTO(entity);
            dto.Token = _jwtService.GenerateToken(entity.Email);

            return dto;
        }

        private UserDTO ToDTO(UserEntity entity)
        {
            var dto = new UserDTO();
            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            dto.Email = entity.Email;
            dto.Active = entity.Active;
            return dto;
        }
    }
}
