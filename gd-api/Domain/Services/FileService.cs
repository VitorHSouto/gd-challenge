using gd_api.Domain.Dtos.Address;
using gd_api.Domain.Dtos.File;
using gd_api.Domain.Entities;
using gd_api.Domain.Repositories;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Services
{
    public class FileService
    {
        private readonly FileRepository _fileRepository;
        public FileService(
            FileRepository fileRepository
        )
        {
            _fileRepository = fileRepository;
        }

        public async Task<FileDTO> GetById(Guid id)
        {
            var entity = await _fileRepository.GetById(id);
            if (entity == null)
                throw new CustomException("Endereço não encontrado.", CustomExceptionError.NotFound);

            return ToDTO(entity);
        }

        private FileDTO ToDTO(FileEntity entity)
        {
            var dto = new FileDTO();
            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            dto.Active = entity.Active;
            dto.Mimetype = entity.Mimetype;
            dto.Extension = entity.Extension;
            dto.publicUrl = entity.publicUrl;
            return dto;
        }
    }
}
