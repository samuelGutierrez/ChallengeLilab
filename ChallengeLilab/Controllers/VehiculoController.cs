using ClubRecreativo.Application.Interfaces;
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
        [HttpGet("acceso/{accesoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerVehiculosPorAcceso()
        {
            var vehiculos = await _servicioVehiculo.ObtenerVehiculosPorAccesoAsync();
            return Ok(vehiculos);
        }
    }
}
