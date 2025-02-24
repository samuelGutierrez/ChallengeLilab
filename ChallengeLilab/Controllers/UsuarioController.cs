using ClubRecreativo.Application.DTOs.Usuarios;
using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubRecreativo.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios del sistema.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicioUsuario _servicioUsuario;

        /// <summary>
        /// Constructor del controlador de usuarios.
        /// </summary
        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _servicioUsuario.ObtenerTodosAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">Información del usuario a crear.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDto usuario)
        {
            await _servicioUsuario.CrearAsync(usuario);
            return Ok("Usuario creado correctamente.");
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="id">ID del usuario a actualizar.</param>
        /// <param name="usuario">Nuevos datos del usuario.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioDto usuario)
        {
            await _servicioUsuario.ActualizarAsync(usuario,id);
            return Ok("Usuario actualizado correctamente.");
        }

        /// <summary>
        /// Elimina un usuario por ID.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            await _servicioUsuario.EliminarAsync(id);
            return Ok("Usuario eliminado correctamente.");
        }
    }
}
