using ClubRecreativo.Application.DTOs.Usuarios;
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

        public async Task<Usuarios> AutenticarAsync(string usuario, string contrasena)
        {
            var user = await _usuarioRepository.GetUsuarioPorCredencialesAsync(usuario, contrasena);
            if (user == null)
                throw new BusinessException("Credenciales inválidas.");

            return user;
        }

        public async Task<IEnumerable<Usuarios>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.GetUsuariosAsync();
        }

        public async Task<Usuarios> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new NotFoundException($"El usuario con ID {id} no fue encontrado.");

            return usuario;
        }

        public async Task CrearAsync(UsuarioDto dto)
        {
            Usuarios usuario = new Usuarios
            {
                RolId = dto.RolId,
                Contrasena = dto.Contrasena,
                NombreCompleto = dto.NombreCompleto,
                Usuario = dto.Usuario
            };

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task ActualizarAsync(UsuarioDto dto, int id)
        {
            var existente = await _usuarioRepository.GetByIdAsync(id);

            existente.RolId = dto.RolId;
            existente.Contrasena = dto.Contrasena;
            existente.Usuario = dto.Usuario;
            existente.NombreCompleto = dto.NombreCompleto;

            await _usuarioRepository.UpdateAsync(existente);
        }

        public async Task EliminarAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
