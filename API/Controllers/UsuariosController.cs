using Application.DTOs;
using Application.Interfaces.Repositories.Generic;
using Application.Interfaces.Repositories.UnitOfWorks;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _usuarioService.ListUsuarios();
            return Ok(response);
        }

        [HttpGet("{usuarioId:int}")]
        public async Task<IActionResult> UsuarioById(int usuarioId)
        {
            var response = await _usuarioService.UsuarioById(usuarioId);
            return Ok(response);
        }
        [HttpPost()]
        public async Task<IActionResult> GuardarUsuario(UsuariosDTO usuariosDTO)
        {
            var response = await _usuarioService.RegisterUsuario(usuariosDTO);
            return Ok(response);
        }
    }
}
