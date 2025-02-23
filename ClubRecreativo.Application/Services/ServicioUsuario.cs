using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Shared.Exceptions;

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
            var user = await _usuarioRepository.GetUsuarioPorCredencialesAsync(usuario, contrasena);
            if (user == null)
                throw new BusinessException("Credenciales inválidas.");

            return user;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.GetUsuariosAsync();
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new NotFoundException($"El usuario con ID {id} no fue encontrado.");

            return usuario;
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
