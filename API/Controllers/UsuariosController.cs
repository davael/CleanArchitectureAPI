using Application.Commons;
using Application.DTOs;
using Application.Interfaces.Repositories.Generic;
using Application.Interfaces.Repositories.UnitOfWorks;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        /// <summary>
        /// Devuelve la lista de usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse<IEnumerable<Usuario>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var response = await _usuarioService.ListUsuarios();
            return Ok(response);
        }

        /// <summary>
        /// Devuelve un usuario por ID
        /// </summary>
        /// <param name="usuarioId">ID del usuario</param>
        /// <returns>Retorna un usuario</returns>
        [HttpGet("{usuarioId:int}")]
        public async Task<IActionResult> UsuarioById(int usuarioId)
        {
            var response = await _usuarioService.UsuarioById(usuarioId);
            return Ok(response);
        }


        /// <summary>
        /// Crea un Usuario
        /// </summary>
        /// <param name="usuariosDTO">Un usuario</param>
        /// <returns>Verdadero o falso</returns>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost()]
        public async Task<IActionResult> GuardarUsuario(UsuarioCreateDTO usuariosDTO)
        {
            var response = await _usuarioService.RegisterUsuario(usuariosDTO);
            return Ok(response);
        }
    }
}
