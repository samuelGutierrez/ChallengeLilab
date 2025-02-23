using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;

namespace ClubRecreativo.Application.Services
{
    public class ServicioUbicacionEstacionamiento : IServicioUbicacionEstacionamiento
    {
        private readonly IUbicacionEstacionamientoRepository _ubicacionRepository;

        public ServicioUbicacionEstacionamiento(IUbicacionEstacionamientoRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }

        public async Task<IEnumerable<UbicacionEstacionamiento>> ObtenerTodosAsync()
        {
            return await _ubicacionRepository.GetAllUbicacionesAsync();
        }

        public async Task<UbicacionEstacionamiento> ObtenerPorIdAsync(int id)
        {
            return await _ubicacionRepository.GetUbicacionByIdAsync(id);
        }
    }
}
