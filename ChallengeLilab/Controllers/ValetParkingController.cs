using ClubRecreativo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubRecreativo.Controllers
{
    /// <summary>
    /// Controlador para gestionar los valets de estacionamiento.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ValetParkingController : ControllerBase
    {
        private readonly IServicioValetParking _servicioValet;

        /// <summary>
        /// Constructor del controlador de valet parking.
        /// </summary>
        public ValetParkingController(IServicioValetParking servicioValet)
        {
            _servicioValet = servicioValet;
        }

        /// <summary>
        /// Obtiene todos los valets registrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var valets = await _servicioValet.ObtenerTodosAsync();
            return Ok(valets);
        }

        /// <summary>
        /// Obtiene un valet específico por su ID.
        /// </summary>
        /// <param name="id">ID del valet.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var valet = await _servicioValet.ObtenerPorIdAsync(id);
            if (valet == null)
                return NotFound("Valet parking no encontrado");

            return Ok(valet);
        }
    }
}
