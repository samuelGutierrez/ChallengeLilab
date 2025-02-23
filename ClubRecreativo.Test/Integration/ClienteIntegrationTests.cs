using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Infrastructure.Repositories;
using FluentAssertions;
using Xunit;

namespace ClubRecreativo.Test.Integration
{
    public class ClienteIntegrationTests : TestBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteIntegrationTests()
        {
            _clienteRepository = new ClienteRepository(_context);
        }

        [Fact]
        public async Task CrearYObtenerCliente_DeberiaFuncionarCorrectamente()
        {
            var cliente = new Cliente
            {
                NombreCompleto = "Carlos Pérez",
                Email = "carlos@test.com",
                Telefono = "1234567890",
                TipoCliente = "Miembro"
            };

            await _clienteRepository.AddAsync(cliente);

            var clienteObtenido = await _clienteRepository.GetClienteByIdAsync(cliente.Id);

            clienteObtenido.Should().NotBeNull();
            clienteObtenido.NombreCompleto.Should().Be("Carlos Pérez");
        }
    }
}
