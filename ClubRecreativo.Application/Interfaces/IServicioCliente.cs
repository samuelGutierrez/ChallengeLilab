using ClubRecreativo.Application.DTOs.Cliente;
using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioCliente
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente> ObtenerPorIdAsync(int id);
        Task CrearAsync(ClienteDto cliente);
        Task ActualizarAsync(ClienteDto cliente, int id);
        Task EliminarAsync(int id);
    }
}
