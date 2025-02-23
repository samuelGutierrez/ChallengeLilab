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

        public async Task CrearAsync(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            var existente = await _clienteRepository.GetClienteByIdAsync(cliente.Id);
            if (existente == null)
                throw new NotFoundException("No se puede actualizar un cliente inexistente.");

            await _clienteRepository.UpdateAsync(cliente);
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
