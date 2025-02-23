using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubRecreativo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IServicioCliente _servicioCliente;

        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var clientes = await _servicioCliente.ObtenerTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerClientePorId(int id)
        {
            var cliente = await _servicioCliente.ObtenerPorIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente)
        {
            await _servicioCliente.CrearAsync(cliente);
            return Ok("Cliente registrado correctamente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, [FromBody] Cliente cliente)
        {
            cliente.Id = id;
            await _servicioCliente.ActualizarAsync(cliente);
            return Ok("Cliente actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            await _servicioCliente.EliminarAsync(id);
            return Ok("Cliente eliminado correctamente");
        }
    }
}
