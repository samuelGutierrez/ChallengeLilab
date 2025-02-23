using ClubRecreativo.Application.Services;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class ServicioUbicacionEstacionamientoTests
    {
        private readonly Mock<IUbicacionEstacionamientoRepository> _ubicacionRepositoryMock;
        private readonly ServicioUbicacionEstacionamiento _servicioUbicacion;

        public ServicioUbicacionEstacionamientoTests()
        {
            _ubicacionRepositoryMock = new Mock<IUbicacionEstacionamientoRepository>();
            _servicioUbicacion = new ServicioUbicacionEstacionamiento(_ubicacionRepositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerTodosAsync_DeberiaRetornarListaDeUbicaciones()
        {
            var ubicaciones = new List<UbicacionEstacionamiento>
            {
                new UbicacionEstacionamiento { Id = 1, CodigoUbicacion = "A1" }
            };
            _ubicacionRepositoryMock.Setup(repo => repo.GetAllUbicacionesAsync())
                .ReturnsAsync(ubicaciones);

            var resultado = await _servicioUbicacion.ObtenerTodosAsync();

            resultado.Should().HaveCount(1);
        }

        [Fact]
        public async Task ObtenerPorIdAsync_UbicacionExistente_DeberiaRetornarUbicacion()
        {
            var ubicacionEsperada = new UbicacionEstacionamiento { Id = 1, CodigoUbicacion = "A1" };
            _ubicacionRepositoryMock.Setup(repo => repo.GetUbicacionByIdAsync(1))
                .ReturnsAsync(ubicacionEsperada);

            var resultado = await _servicioUbicacion.ObtenerPorIdAsync(1);

            resultado.Should().NotBeNull();
            resultado.CodigoUbicacion.Should().Be("A1");
        }
    }
}
