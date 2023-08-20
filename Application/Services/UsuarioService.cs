using Application.Commons;
using Application.DTOs;
using Application.Interfaces.Repositories.UnitOfWorks;
using Application.Interfaces.Services;
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

        public UsuarioService(IUnitOfWorks unitOfWorks, IMapper mapper, ILogger<UsuarioService> logger)
        {
            _unitOfWork = unitOfWorks;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<IEnumerable<Usuario>>> ListUsuarios()
        {
            var response = new BaseResponse<IEnumerable<Usuario>>();

            var usuarios = await _unitOfWork.Usuario.GetAll();
            if (usuarios != null)
            {
                response.IsSuccess = true;
                response.Data = usuarios;
                response.Message = "Consulta exitosa";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros";
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterUsuario(UsuariosDTO usuarioDTO)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                response.Data = await _unitOfWork.Usuario.Add(usuario);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se guardo correctamente";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Fallo la operacion";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess=false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<UsuariosDTO>> UsuarioById(int usuarioId)
        {
            var response = new BaseResponse<UsuariosDTO>();
            var usuario = await _unitOfWork.Usuario.GetById(usuarioId);
            if (usuario != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<UsuariosDTO>(usuario);
                response.Message = "Consulta exitosa";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros";
                _logger.LogWarning("No existen registros");
            }
            return response;
        }
    }
}
