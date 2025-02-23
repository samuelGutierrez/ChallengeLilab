using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Domain.Interfaces
{
    public interface IAccesoRepository
    {
        Task<IEnumerable<Acceso>> GetAccesosByClienteIdAsync(int clienteId);
        Task<Acceso> GetAccesoByIdAsync(int id);
        Task AddAsync(Acceso acceso);
        Task UpdateAsync(Acceso acceso);
        Task DeleteAsync(int id);
    }
}
