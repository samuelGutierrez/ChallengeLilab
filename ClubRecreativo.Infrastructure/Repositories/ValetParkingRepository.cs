using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Infrastructure.Repositories
{
    public class ValetParkingRepository : IValetParkingRepository
    {
        private readonly ClubRecreativoContext _context;

        public ValetParkingRepository(ClubRecreativoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ValetParking>> GetAllValetParkingsAsync()
        {
            return await _context.ValetParkings.ToListAsync();
        }

        public async Task<ValetParking> GetValetParkingByIdAsync(int id)
        {
            return await _context.ValetParkings.FindAsync(id);
        }

        public async Task AddAsync(ValetParking valetParking)
        {
            await _context.ValetParkings.AddAsync(valetParking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ValetParking valetParking)
        {
            _context.ValetParkings.Update(valetParking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var valet = await GetValetParkingByIdAsync(id);
            if (valet != null)
            {
                _context.ValetParkings.Remove(valet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
