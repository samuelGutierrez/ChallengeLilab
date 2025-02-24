using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Infrastructure.Repositories;
using FluentAssertions;
using Xunit;

namespace ClubRecreativo.Test.Integration
{
    public class UsuarioIntegrationTests : TestBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioIntegrationTests()
        {
            _usuarioRepository = new UsuarioRepository(_context);
        }

        [Fact]
        public async Task CrearYObtenerUsuario_DeberiaFuncionarCorrectamente()
        {
            var usuario = new Usuarios
            {
                NombreCompleto = "Admin User",
                Usuario = "admin",
                Contrasena = "1234",
                RolId = 1
            };

            await _usuarioRepository.AddAsync(usuario);

            var usuarioObtenido = await _usuarioRepository.GetByIdAsync(usuario.Id);

            usuarioObtenido.Should().NotBeNull();
            usuarioObtenido.Usuario.Should().Be("admin");
        }

        [Fact]
        public async Task AutenticarUsuario_DeberiaRetornarUsuarioValido()
        {
            var usuario = new Usuarios
            {
                NombreCompleto = "Test User",
                Usuario = "testuser",
                Contrasena = "password",
                RolId = 2
            };

            await _usuarioRepository.AddAsync(usuario);

            var usuarioAutenticado = await _usuarioRepository.GetUsuarioPorCredencialesAsync("testuser", "password");

            usuarioAutenticado.Should().NotBeNull();
            usuarioAutenticado.Usuario.Should().Be("testuser");
        }
    }
}
