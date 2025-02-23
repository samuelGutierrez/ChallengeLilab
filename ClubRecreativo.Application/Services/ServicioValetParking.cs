using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;

namespace ClubRecreativo.Application.Services
{
    public class ServicioValetParking : IServicioValetParking
    {
        private readonly IValetParkingRepository _valetParkingRepository;

        public ServicioValetParking(IValetParkingRepository valetParkingRepository)
        {
            _valetParkingRepository = valetParkingRepository;
        }

        public async Task<IEnumerable<ValetParking>> ObtenerTodosAsync()
        {
            return await _valetParkingRepository.GetAllValetParkingsAsync();
        }

        public async Task<ValetParking> ObtenerPorIdAsync(int id)
        {
            return await _valetParkingRepository.GetValetParkingByIdAsync(id);
        }
    }
}
