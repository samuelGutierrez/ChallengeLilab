using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Shared.Exceptions;

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
            if (vehiculo == null)
                throw new NotFoundException($"Vehículo con ID {vehiculoId} no fue encontrado.");

            if (vehiculo.FechaSalida != null)
                throw new BusinessException("El vehículo ya ha registrado su salida.");

            vehiculo.FechaSalida = DateTime.UtcNow;
            await _vehiculoRepository.UpdateAsync(vehiculo);
        }
    }
}
