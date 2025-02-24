using ClubRecreativo.Application.DTOs.Acceso;
using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubRecreativo.Controllers
{
    /// <summary>
    /// Controlador para gestionar accesos de clientes en el Club Recreativo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccesoController : ControllerBase
    {
        private readonly IServicioAcceso _servicioAcceso;


        /// <summary>
        /// Constructor del controlador de accesos.
        /// </summary>
        /// <param name="servicioAcceso">Servicio de acceso inyectado.</param>
        public AccesoController(IServicioAcceso servicioAcceso)
        {
            _servicioAcceso = servicioAcceso;
        }

        /// <summary>
        /// Obtiene los accesos registrados de un cliente específico.
        /// </summary>
        /// <param name="clienteId">El ID del cliente.</param>
        /// <returns>Lista de accesos con fechas de entrada y salida.</returns>
        /// <response code="200">Lista de accesos encontrada exitosamente.</response>
        /// <response code="404">No se encontraron accesos para el cliente especificado.</response>
        [HttpGet("cliente/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerAccesosPorCliente(int clienteId)
        {
            var accesos = await _servicioAcceso.ObtenerAccesosPorClienteAsync(clienteId);
            return Ok(accesos);
        }

        /// <summary>
        /// Registra una nueva entrada de un cliente.
        /// </summary>
        /// <param name="acceso">Datos del acceso (cliente, fecha de entrada, etc.).</param>
        /// <returns>Confirmación de entrada registrada.</returns>
        /// <response code="200">Entrada registrada correctamente.</response>
        /// <response code="400">Los datos proporcionados no son válidos.</response>
        [HttpPost("entrada")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarEntrada([FromBody] EntradaDto acceso)
        {
            await _servicioAcceso.RegistrarEntradaAsync(acceso);
            return Ok("Entrada registrada correctamente");
        }

        /// <summary>
        /// Registra la salida de un cliente mediante el ID de acceso.
        /// </summary>
        /// <param name="id">ID del acceso registrado.</param>
        /// <returns>Confirmación de salida registrada.</returns>
        /// <response code="200">Salida registrada correctamente.</response>
        /// <response code="404">No se encontró el acceso especificado.</response>
        [HttpPut("salida/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarSalida(int id)
        {
            await _servicioAcceso.RegistrarSalidaAsync(id);
            return Ok("Salida registrada correctamente");
        }
    }
}
