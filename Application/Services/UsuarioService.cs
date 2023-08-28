using Application.Commons;
using Application.DTOs;
using Application.Interfaces.Repositories.UnitOfWorks;
using Application.Interfaces.Services;
using Application.Utilities;
using Application.Validators;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioService> _logger;
        private readonly UsuarioValidator _validationRules;

        public UsuarioService(IUnitOfWorks unitOfWorks, IMapper mapper, ILogger<UsuarioService> logger, UsuarioValidator validationRules)
        {
            _unitOfWork = unitOfWorks;
            _mapper = mapper;
            _logger = logger;
            _validationRules = validationRules;
        }
        public async Task<BaseResponse<IEnumerable<Usuario>>> ListUsuarios()
        {
            var response = new BaseResponse<IEnumerable<Usuario>>();

            var usuarios = await _unitOfWork.Usuario.GetAll();
            if (usuarios != null)
            {
                response.IsSuccess = true;
                response.Data = usuarios;
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterUsuario(UsuarioCreateDTO usuarioDTO)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var validationResult = await _validationRules.ValidateAsync(usuarioDTO);
                if (!validationResult.IsValid) 
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                    return response;
                }
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                response.Data = await _unitOfWork.Usuario.Add(usuario);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    _logger.LogError("se guardo muy bien el registro");
                    response.Message = ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<UsuarioCreateDTO>> UsuarioById(int usuarioId)
        {
            var response = new BaseResponse<UsuarioCreateDTO>();
            var usuario = await _unitOfWork.Usuario.GetById(usuarioId);
            if (usuario != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<UsuarioCreateDTO>(usuario);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
    }
}
