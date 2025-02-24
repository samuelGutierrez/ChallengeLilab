using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> GetUsuarioPorCredencialesAsync(string usuario, string contrasena);
        Task<IEnumerable<Usuarios>> GetUsuariosAsync();
        Task<Usuarios> GetByIdAsync(int id);
        Task AddAsync(Usuarios usuario);
        Task UpdateAsync(Usuarios usuario);
        Task DeleteAsync(int id);
    }
}
