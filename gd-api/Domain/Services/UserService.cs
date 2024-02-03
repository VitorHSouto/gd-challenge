using gd_api.Domain.Dtos.User;
using gd_api.Domain.Entities;
using gd_api.Domain.Helpers;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService(
            UserRepository userRepository
        )
        {
            _userRepository = userRepository;
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
            entity.Password = TokenHelper.EncodeString(req.Password);

            await _userRepository.Save(entity);
            return ToDTO(entity);
        }

        public async Task<UserDTO> GetByLogin(string email, string password)
        {
            var encodedPassword = TokenHelper.EncodeString(password);
            var entity = await _userRepository.GetByLogin(email, encodedPassword);
            if (entity == null)
                throw new Exception("E-mail ou senha inválido.");

            return ToDTO(entity);
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
