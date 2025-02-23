using ClubRecreativo.Domain.Entities;

namespace ClubRecreativo.Domain.Interfaces
{
    public interface IValetParkingRepository
    {
        Task<IEnumerable<ValetParking>> GetAllValetParkingsAsync();
        Task<ValetParking> GetValetParkingByIdAsync(int id);
    }
}
