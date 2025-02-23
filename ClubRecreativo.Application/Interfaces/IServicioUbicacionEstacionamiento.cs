using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioUbicacionEstacionamiento
    {
        Task<IEnumerable<UbicacionEstacionamiento>> ObtenerTodosAsync();
        Task<UbicacionEstacionamiento> ObtenerPorIdAsync(int id);
    }
}
