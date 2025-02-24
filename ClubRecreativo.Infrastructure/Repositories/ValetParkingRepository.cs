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
            return await _context.ValetParking.ToListAsync();
        }

        public async Task<ValetParking> GetValetParkingByIdAsync(int id)
        {
            return await _context.ValetParking.FindAsync(id);
        }

        public async Task AddAsync(ValetParking valetParking)
        {
            await _context.ValetParking.AddAsync(valetParking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ValetParking valetParking)
        {
            _context.ValetParking.Update(valetParking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var valet = await GetValetParkingByIdAsync(id);
            if (valet != null)
            {
                _context.ValetParking.Remove(valet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
