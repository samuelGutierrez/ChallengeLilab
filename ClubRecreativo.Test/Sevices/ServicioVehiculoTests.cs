using ClubRecreativo.Application.Services;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using Moq;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class ServicioVehiculoTests
    {
        private readonly Mock<IVehiculoRepository> _vehiculoRepositoryMock;
        private readonly ServicioVehiculo _servicioVehiculo;

        public ServicioVehiculoTests()
        {
            _vehiculoRepositoryMock = new Mock<IVehiculoRepository>();
            _servicioVehiculo = new ServicioVehiculo(_vehiculoRepositoryMock.Object);
        }

        [Fact]
        public async Task RegistrarVehiculoAsync_DeberiaAgregarVehiculoCorrectamente()
        {
            var vehiculo = new Vehiculo { Marca = "Toyota", Modelo = "Corolla" };

            await _servicioVehiculo.RegistrarVehiculoAsync(vehiculo);

            _vehiculoRepositoryMock.Verify(repo => repo.AddAsync(vehiculo), Times.Once);
        }

        [Fact]
        public async Task RegistrarSalidaVehiculoAsync_DeberiaRegistrarSalidaCorrectamente()
        {
            var vehiculo = new Vehiculo { Id = 1, FechaEntrada = DateTime.UtcNow };
            _vehiculoRepositoryMock.Setup(repo => repo.GetVehiculoByIdAsync(1))
                .ReturnsAsync(vehiculo);

            await _servicioVehiculo.RegistrarSalidaVehiculoAsync(1);

            _vehiculoRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Vehiculo>(v => v.FechaSalida != null)), Times.Once);
        }
    }
}
