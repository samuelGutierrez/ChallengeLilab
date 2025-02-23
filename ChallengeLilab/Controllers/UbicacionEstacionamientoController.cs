using ClubRecreativo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubRecreativo.Controllers
{
    /// <summary>
    /// Controlador para gestionar las ubicaciones de estacionamiento.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UbicacionEstacionamientoController : ControllerBase
    {
        private readonly IServicioUbicacionEstacionamiento _servicioUbicacion;

        /// <summary>
        /// Constructor del controlador de ubicaciones de estacionamiento.
        /// </summary>
        public UbicacionEstacionamientoController(IServicioUbicacionEstacionamiento servicioUbicacion)
        {
            _servicioUbicacion = servicioUbicacion;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones de estacionamiento disponibles.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodas()
        {
            var ubicaciones = await _servicioUbicacion.ObtenerTodosAsync();
            return Ok(ubicaciones);
        }

        /// <summary>
        /// Obtiene una ubicación específica por su ID.
        /// </summary>
        /// <param name="id">ID de la ubicación de estacionamiento.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var ubicacion = await _servicioUbicacion.ObtenerPorIdAsync(id);
            if (ubicacion == null)
                return NotFound("Ubicación no encontrada");

            return Ok(ubicacion);
        }
    }
}
