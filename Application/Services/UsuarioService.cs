using Application.Commons;
using Application.Interfaces.Repositories.UnitOfWorks;
using Application.Interfaces.Services;
using Domain.Entities;
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

        public UsuarioService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWork = unitOfWorks;
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

        public async Task<BaseResponse<Usuario>> UsuarioById(int usuarioId)
        {
            var response = new BaseResponse<Usuario>();
            var usuario = await _unitOfWork.Usuario.GetById(usuarioId);
            if (usuario != null)
            {
                response.IsSuccess = true;
                response.Data = usuario;
                response.Message = "Consulta exitosa";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros";
            }
            return response;
        }
    }
}
