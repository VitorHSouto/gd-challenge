﻿using Azure.Core;
using gd_api.Domain.Dtos.User;
using gd_api.Domain.Entities;
using gd_api.Domain.Helpers;
using gd_api.Domain.Repositories;
using gd_api.Domain.Settings;
using System.Net;
using System.Web.Http;

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
                throw new CustomException("Usuário não encontrado.", CustomExceptionError.NotFound);

            return ToDTO(entity);
        }

        public async Task<UserDTO> Save(RequestSaveUserDTO req)
        {
            ValidateSaveUserDTO(req);

            var entity = new UserEntity();
            entity.Name = req.Name;
            entity.Email = req.Email;
            entity.Password = TokenHelper.EncodeString(req.Password);

            await _userRepository.Save(entity);
            return ToDTO(entity);
        }

        private void ValidateSaveUserDTO(RequestSaveUserDTO req)
        {
            if (req == null)
                throw new CustomException("Não foi possível criar um usuário", CustomExceptionError.FormError);

            if (string.IsNullOrEmpty(req.Name))
                throw new CustomException("Defina o nome do usuário", CustomExceptionError.FormError);

            if (req.Name.Length > 100)
                throw new CustomException("O limite de caracteres do nome é de 100", CustomExceptionError.FormError);

            if (string.IsNullOrEmpty(req.Email))
                throw new CustomException("Defina o e-mail do usuário", CustomExceptionError.FormError);

            if (string.IsNullOrEmpty(req.Password))
                throw new CustomException("Defina a senha do usuário", CustomExceptionError.FormError);
        }

        public async Task<UserDTO> GetByLogin(string email, string password)
        {
            var encodedPassword = TokenHelper.EncodeString(password);
            var entity = await _userRepository.GetByLogin(email, encodedPassword);
            if (entity == null)
                throw new CustomException("E-mail ou senha inválido.", CustomExceptionError.FormError);

            return ToDTO(entity);
        }

        private UserDTO ToDTO(UserEntity entity)
        {
            var dto = new UserDTO();
            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            dto.UpdatedAt = entity.UpdatedAt;
            dto.Name = entity.Name;
            dto.Email = entity.Email;
            dto.Active = entity.Active;
            return dto;
        }
    }
}
