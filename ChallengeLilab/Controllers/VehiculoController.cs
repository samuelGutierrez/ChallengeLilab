using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubRecreativo.Controllers
{
    /// <summary>
    /// Controlador para gestionar los vehículos de los clientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VehiculoController : ControllerBase
    {
        private readonly IServicioVehiculo _servicioVehiculo;

        /// <summary>
        /// Constructor del controlador de vehículos.
        /// </summary>
        public VehiculoController(IServicioVehiculo servicioVehiculo)
        {
            _servicioVehiculo = servicioVehiculo;
        }

        /// <summary>
        /// Obtiene los vehículos asociados a un acceso específico.
        /// </summary>
        /// <param name="accesoId">ID del acceso.</param>
        [HttpGet("acceso/{accesoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerVehiculosPorAcceso(int accesoId)
        {
            var vehiculos = await _servicioVehiculo.ObtenerVehiculosPorAccesoAsync(accesoId);
            return Ok(vehiculos);
        }

        /// <summary>
        /// Registra un nuevo vehículo.
        /// </summary>
        /// <param name="vehiculo">Datos del vehículo.</param>
        [HttpPost("registro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegistrarVehiculo([FromBody] Vehiculo vehiculo)
        {
            await _servicioVehiculo.RegistrarVehiculoAsync(vehiculo);
            return Ok("Vehículo registrado correctamente");
        }

        /// <summary>
        /// Registra la salida de un vehículo.
        /// </summary>
        /// <param name="id">ID del vehículo.</param>
        [HttpPut("salida/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegistrarSalidaVehiculo(int id)
        {
            await _servicioVehiculo.RegistrarSalidaVehiculoAsync(id);
            return Ok("Salida de vehículo registrada correctamente");
        }
    }
}
