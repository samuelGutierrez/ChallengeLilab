using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Infrastructure.Repositories;
using FluentAssertions;
using Xunit;

namespace ClubRecreativo.Test.Integration
{
    public class AccesoIntegrationTests : TestBase
    {
        private readonly AccesoRepository _accesoRepository;

        public AccesoIntegrationTests()
        {
            _accesoRepository = new AccesoRepository(_context);
        }

        [Fact]
        public async Task RegistrarEntradaYSalida_DeberiaRegistrarCorrectamente()
        {
            var acceso = new Acceso
            {
                ClienteId = 1,
                FechaEntrada = DateTime.UtcNow
            };

            await _accesoRepository.AddAsync(acceso);

            acceso.FechaSalida = DateTime.UtcNow.AddHours(2);
            await _accesoRepository.UpdateAsync(acceso);

            var accesoObtenido = await _accesoRepository.GetAccesoByIdAsync(acceso.Id);

            accesoObtenido.Should().NotBeNull();
            accesoObtenido.FechaSalida.Should().NotBeNull();
        }
    }
}
