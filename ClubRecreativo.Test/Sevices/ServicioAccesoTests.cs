using ClubRecreativo.Application.Services;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using Moq;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class ServicioAccesoTests
    {
        private readonly Mock<IAccesoRepository> _accesoRepositoryMock;
        private readonly ServicioAcceso _servicioAcceso;

        public ServicioAccesoTests()
        {
            _accesoRepositoryMock = new Mock<IAccesoRepository>();
            _servicioAcceso = new ServicioAcceso(_accesoRepositoryMock.Object);
        }

        [Fact]
        public async Task RegistrarEntradaAsync_DeberiaRegistrarEntradaCorrectamente()
        {
            // Arrange
            var acceso = new Acceso { ClienteId = 1 };

            // Act
            await _servicioAcceso.RegistrarEntradaAsync(acceso);

            // Assert
            _accesoRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Acceso>(a => a.FechaEntrada != null)), Times.Once);
        }

        [Fact]
        public async Task RegistrarSalidaAsync_DeberiaRegistrarSalidaCorrectamente()
        {
            // Arrange
            var acceso = new Acceso { Id = 1, FechaEntrada = DateTime.UtcNow };
            _accesoRepositoryMock.Setup(repo => repo.GetAccesoByIdAsync(1))
                .ReturnsAsync(acceso);

            // Act
            await _servicioAcceso.RegistrarSalidaAsync(1);

            // Assert
            _accesoRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Acceso>(a => a.FechaSalida != null)), Times.Once);
        }
    }
}
