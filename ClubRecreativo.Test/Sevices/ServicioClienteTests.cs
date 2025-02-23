using ClubRecreativo.Application.Services;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class ServicioClienteTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ServicioCliente _servicioCliente;

        public ServicioClienteTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _servicioCliente = new ServicioCliente(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task CrearAsync_DeberiaAgregarClienteCorrectamente()
        {
            // Arrange
            var cliente = new Cliente { NombreCompleto = "Juan Pérez" };

            // Act
            await _servicioCliente.CrearAsync(cliente);

            // Assert
            _clienteRepositoryMock.Verify(repo => repo.AddAsync(cliente), Times.Once);
        }

        [Fact]
        public async Task ObtenerPorIdAsync_ClienteExistente_DeberiaRetornarCliente()
        {
            // Arrange
            var clienteEsperado = new Cliente { Id = 1, NombreCompleto = "Juan Pérez" };
            _clienteRepositoryMock.Setup(repo => repo.GetClienteByIdAsync(1))
                .ReturnsAsync(clienteEsperado);

            // Act
            var resultado = await _servicioCliente.ObtenerPorIdAsync(1);

            // Assert
            resultado.Should().NotBeNull();
            resultado.NombreCompleto.Should().Be("Juan Pérez");
        }
    }
}
