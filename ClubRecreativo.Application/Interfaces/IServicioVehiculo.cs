using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioVehiculo
    {
        Task<IEnumerable<Vehiculo>> ObtenerVehiculosPorAccesoAsync();
        Task RegistrarVehiculoAsync(Vehiculo vehiculo);
        Task RegistrarSalidaVehiculoAsync(int vehiculoId);
    }
}
