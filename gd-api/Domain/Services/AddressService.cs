using gd_api.Domain.Dtos.Address;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;

namespace gd_api.Domain.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;
        public AddressService(
            AddressRepository addressRepository
        )
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressDTO> GetById(Guid id)
        {
            var entity = await _addressRepository.GetById(id);
            if (entity == null)
                throw new Exception("Endereço não encontrado");

            return ToDTO(entity);
        }

        private AddressDTO ToDTO(AddressEntity entity)
        {
            var dto = new AddressDTO();
            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            dto.Active = entity.Active;
            dto.Street = entity.Street;
            dto.City = entity.City;
            dto.State = entity.State;
            dto.Number = entity.Number;
            dto.ZipCode = entity.ZipCode;
            return dto;
        }
    }
}
