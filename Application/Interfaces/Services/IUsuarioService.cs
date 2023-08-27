using Application.Commons;
using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<BaseResponse<IEnumerable<Usuario>>> ListUsuarios();
        Task<BaseResponse<UsuarioCreateDTO>> UsuarioById(int usuarioId);
        Task<BaseResponse<bool>> RegisterUsuario(UsuarioCreateDTO usuarioDTO);

    }
}
