using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioVehiculo
    {
        Task<IEnumerable<Vehiculo>> ObtenerVehiculosPorAccesoAsync(int accesoId);
        Task RegistrarVehiculoAsync(Vehiculo vehiculo);
        Task RegistrarSalidaVehiculoAsync(int vehiculoId);
    }
}
