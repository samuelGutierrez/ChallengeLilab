using ClubRecreativo.Application.DTOs.Usuarios;
using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Application.Interfaces
{
    public interface IServicioUsuario
    {
        Task<Usuarios> AutenticarAsync(string usuario, string contrasena);
        Task<IEnumerable<Usuarios>> ObtenerTodosAsync();
        Task<Usuarios> ObtenerPorIdAsync(int id);
        Task CrearAsync(UsuarioDto usuario);
        Task ActualizarAsync(UsuarioDto usuario,int id);
        Task EliminarAsync(int id);
    }
}
