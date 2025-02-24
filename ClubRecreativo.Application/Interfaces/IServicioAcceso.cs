using ClubRecreativo.Application.DTOs.Acceso;
using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioAcceso
    {
        Task<IEnumerable<Acceso>> ObtenerAccesosPorClienteAsync(int clienteId);
        Task RegistrarEntradaAsync(EntradaDto acceso);
        Task RegistrarSalidaAsync(int accesoId);
    }
}
