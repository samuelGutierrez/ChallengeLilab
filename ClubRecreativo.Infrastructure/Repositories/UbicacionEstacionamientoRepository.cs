using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Infrastructure.Repositories
{
    public class UbicacionEstacionamientoRepository : IUbicacionEstacionamientoRepository
    {
        private readonly ClubRecreativoContext _context;

        public UbicacionEstacionamientoRepository(ClubRecreativoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UbicacionEstacionamiento>> GetAllUbicacionesAsync()
        {
            return await _context.UbicacionesEstacionamiento.ToListAsync();
        }

        public async Task<UbicacionEstacionamiento> GetUbicacionByIdAsync(int id)
        {
            return await _context.UbicacionesEstacionamiento.FindAsync(id);
        }

        public async Task AddAsync(UbicacionEstacionamiento ubicacion)
        {
            await _context.UbicacionesEstacionamiento.AddAsync(ubicacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UbicacionEstacionamiento ubicacion)
        {
            _context.UbicacionesEstacionamiento.Update(ubicacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ubicacion = await GetUbicacionByIdAsync(id);
            if (ubicacion != null)
            {
                _context.UbicacionesEstacionamiento.Remove(ubicacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
