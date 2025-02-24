using ClubRecreativo.Application.DTOs.Cliente;
using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Shared.Exceptions;

namespace ClubRecreativo.Application.Services
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IClienteRepository _clienteRepository;

        public ServicioCliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> ObtenerPorIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException($"El cliente con ID {id} no fue encontrado.");

            return cliente;
        }

        public async Task CrearAsync(ClienteDto dto)
        {
            Cliente cliente = new Cliente
            {
                Email = dto.Email,
                NombreCompleto = dto.NombreCompleto,
                Telefono = dto.Telefono,
                TipoCliente = dto.TipoCliente,
            };

            await _clienteRepository.AddAsync(cliente);
        }

        public async Task ActualizarAsync(ClienteDto dto, int id)
        {
            var existente = await _clienteRepository.GetClienteByIdAsync(id);
            if (existente == null)
                throw new NotFoundException("No se puede actualizar un cliente inexistente.");

            existente.Email = dto.Email;
            existente.TipoCliente = dto.TipoCliente;
            existente.Telefono = dto.Telefono;
            existente.NombreCompleto = dto.NombreCompleto;

            await _clienteRepository.UpdateAsync(existente);
        }

        public async Task EliminarAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException("No se puede eliminar un cliente inexistente.");

            await _clienteRepository.DeleteAsync(id);
        }
    }
}
