using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Infrastructure.Repositories;
using FluentAssertions;
using Xunit;

namespace ClubRecreativo.Test.Integration
{
    public class VehiculoIntegrationTests : TestBase
    {
        private readonly VehiculoRepository _vehiculoRepository;

        public VehiculoIntegrationTests()
        {
            _vehiculoRepository = new VehiculoRepository(_context);
        }

        [Fact]
        public async Task RegistrarVehiculoYSalida_DeberiaFuncionarCorrectamente()
        {
            var vehiculo = new Vehiculo
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Placa = "ABC123",
                AccesoId = 1,
                ValetParkingId = 1,
                UbicacionEstacionamientoId = 1,
                FechaEntrada = DateTime.UtcNow
            };

            await _vehiculoRepository.AddAsync(vehiculo);

            vehiculo.FechaSalida = DateTime.UtcNow.AddHours(3);
            await _vehiculoRepository.UpdateAsync(vehiculo);

            var vehiculoObtenido = await _vehiculoRepository.GetVehiculoByIdAsync(vehiculo.Id);

            vehiculoObtenido.Should().NotBeNull();
            vehiculoObtenido.FechaSalida.Should().NotBeNull();
        }
    }
}
