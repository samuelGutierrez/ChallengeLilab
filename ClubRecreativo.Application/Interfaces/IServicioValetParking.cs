using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioValetParking
    {
        Task<IEnumerable<ValetParking>> ObtenerTodosAsync();
        Task<ValetParking> ObtenerPorIdAsync(int id);
    }
}
