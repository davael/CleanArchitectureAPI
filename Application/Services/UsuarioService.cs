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
            if(usuarios != null)
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
