using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Shared.Exceptions;

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
            var valet = await _valetParkingRepository.GetValetParkingByIdAsync(id);
            if (valet == null)
                throw new NotFoundException($"El valet parking con ID {id} no fue encontrado.");

            return valet;
        }
    }
}
