using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserEntity>> ListAll()
        {
            return await _userRepository.ListAll();
        }

        public async Task<UserEntity> GetById(Guid id)
        {
            var entity = await _userRepository.GetById(id);
            if (entity == null)
                throw new Exception("Usuário não encontrado.");

            return entity;
        }
    }
}
