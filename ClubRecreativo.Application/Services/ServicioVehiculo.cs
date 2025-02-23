using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;

namespace ClubRecreativo.Application.Services
{
    public class ServicioVehiculo : IServicioVehiculo
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public ServicioVehiculo(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerVehiculosPorAccesoAsync(int accesoId)
        {
            return await _vehiculoRepository.GetVehiculosByAccesoIdAsync(accesoId);
        }

        public async Task RegistrarVehiculoAsync(Vehiculo vehiculo)
        {
            vehiculo.FechaEntrada = DateTime.UtcNow;
            await _vehiculoRepository.AddAsync(vehiculo);
        }

        public async Task RegistrarSalidaVehiculoAsync(int vehiculoId)
        {
            var vehiculo = await _vehiculoRepository.GetVehiculoByIdAsync(vehiculoId);
            if (vehiculo != null && vehiculo.FechaSalida == null)
            {
                vehiculo.FechaSalida = DateTime.UtcNow;
                await _vehiculoRepository.UpdateAsync(vehiculo);
            }
        }
    }
}
