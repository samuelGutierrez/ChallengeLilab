using ClubRecreativo.Application.Services;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class ServicioValetParkingTests
    {
        private readonly Mock<IValetParkingRepository> _valetParkingRepositoryMock;
        private readonly ServicioValetParking _servicioValetParking;

        public ServicioValetParkingTests()
        {
            _valetParkingRepositoryMock = new Mock<IValetParkingRepository>();
            _servicioValetParking = new ServicioValetParking(_valetParkingRepositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerTodosAsync_DeberiaRetornarListaDeValets()
        {
            var valets = new List<ValetParking> { new ValetParking { Id = 1, NombreCompleto = "Pedro" } };
            _valetParkingRepositoryMock.Setup(repo => repo.GetAllValetParkingsAsync())
                .ReturnsAsync(valets);

            var resultado = await _servicioValetParking.ObtenerTodosAsync();

            resultado.Should().HaveCount(1);
        }

        [Fact]
        public async Task ObtenerPorIdAsync_ValetExistente_DeberiaRetornarValet()
        {
            var valetEsperado = new ValetParking { Id = 1, NombreCompleto = "Pedro" };
            _valetParkingRepositoryMock.Setup(repo => repo.GetValetParkingByIdAsync(1))
                .ReturnsAsync(valetEsperado);

            var resultado = await _servicioValetParking.ObtenerPorIdAsync(1);

            resultado.Should().NotBeNull();
            resultado.NombreCompleto.Should().Be("Pedro");
        }
    }
}
