using ClubRecreativo.Application.DTOs.Auth;
using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClubRecreativo.Controllers
{
    /// <summary>
    /// Controlador para autenticación de usuarios en el Club Recreativo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServicioUsuario _servicioUsuario;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor del controlador de autenticación.
        /// </summary>
        /// <param name="servicioUsuario">Servicio de usuario inyectado.</param>
        /// <param name="configuration">Configuración de la aplicación (IConfiguration).</param>
        public AuthController(IServicioUsuario servicioUsuario, IConfiguration configuration)
        {
            _servicioUsuario = servicioUsuario;
            _configuration = configuration;
        }

        /// <summary>
        /// Autentica un usuario y genera un token JWT.
        /// </summary>
        /// <param name="login">Objeto que contiene el nombre de usuario y la contraseña.</param>
        /// <returns>Token JWT si las credenciales son válidas.</returns>
        /// <response code="200">Token JWT generado exitosamente.</response>
        /// <response code="401">Credenciales inválidas.</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var usuario = await _servicioUsuario.AutenticarAsync(login.UsuarioNombre, login.Contrasena);

            if (usuario == null) return Unauthorized("Credenciales inválidas.");

            var token = GenerateJwtToken(usuario);
            return Ok(new { token });
        }

        #region Private

        /// <summary>
        /// Genera un token JWT para el usuario autenticado.
        /// </summary>
        /// <param name="usuario">El usuario autenticado.</param>
        /// <returns>Un string con el token JWT.</returns>
        private string GenerateJwtToken(Usuarios usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Usuario),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}
