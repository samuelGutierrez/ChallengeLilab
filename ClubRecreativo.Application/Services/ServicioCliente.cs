using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;

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
            return await _clienteRepository.GetClienteByIdAsync(id);
        }

        public async Task CrearAsync(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task EliminarAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}
