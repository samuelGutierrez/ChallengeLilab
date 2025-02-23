using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;

namespace ClubRecreativo.Application.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ServicioUsuario(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AutenticarAsync(string usuario, string contrasena)
        {
            return await _usuarioRepository.GetUsuarioPorCredencialesAsync(usuario, contrasena);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.GetUsuariosAsync();
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task CrearAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task EliminarAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
