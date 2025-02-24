using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Domain.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo> GetVehiculosByAccesoIdAsync(int accesoId);
        Task<Vehiculo> GetVehiculoByIdAsync(int id);
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(int id);
        Task<Vehiculo> GetVehiculoByPlacaAsync(string placa);
        Task<bool> EstaUbicacionOcupadaAsync(int ubicacionEstacionamientoId);
        Task<IEnumerable<Vehiculo>> GetVehiculosAsync();
    }
}
