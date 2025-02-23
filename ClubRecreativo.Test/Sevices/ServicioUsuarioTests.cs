using ClubRecreativo.Application.Services;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class ServicioUsuarioTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly ServicioUsuario _servicioUsuario;

        public ServicioUsuarioTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _servicioUsuario = new ServicioUsuario(_usuarioRepositoryMock.Object);
        }

        [Fact]
        public async Task AutenticarAsync_UsuarioValido_DeberiaRetornarUsuario()
        {
            // Arrange
            var usuarioEsperado = new Usuario { UsuarioNombre = "admin", Contrasena = "1234" };
            _usuarioRepositoryMock.Setup(repo => repo.GetUsuarioPorCredencialesAsync("admin", "1234"))
                .ReturnsAsync(usuarioEsperado);

            // Act
            var resultado = await _servicioUsuario.AutenticarAsync("admin", "1234");

            // Assert
            resultado.Should().NotBeNull();
            resultado.UsuarioNombre.Should().Be("admin");
        }

        [Fact]
        public async Task AutenticarAsync_UsuarioInvalido_DeberiaRetornarNull()
        {
            // Arrange
            _usuarioRepositoryMock.Setup(repo => repo.GetUsuarioPorCredencialesAsync("admin", "wrongpassword"))
                .ReturnsAsync((Usuario)null);

            // Act
            var resultado = await _servicioUsuario.AutenticarAsync("admin", "wrongpassword");

            // Assert
            resultado.Should().BeNull();
        }
    }
}
