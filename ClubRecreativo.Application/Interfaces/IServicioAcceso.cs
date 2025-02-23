using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioAcceso
    {
        Task<IEnumerable<Acceso>> ObtenerAccesosPorClienteAsync(int clienteId);
        Task RegistrarEntradaAsync(Acceso acceso);
        Task RegistrarSalidaAsync(int accesoId);
    }
}
