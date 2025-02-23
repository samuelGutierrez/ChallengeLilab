using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Domain.Interfaces
{
    public interface IUbicacionEstacionamientoRepository
    {
        Task<IEnumerable<UbicacionEstacionamiento>> GetAllUbicacionesAsync();
        Task<UbicacionEstacionamiento> GetUbicacionByIdAsync(int id);
    }
}
