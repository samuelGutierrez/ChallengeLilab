using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Infrastructure.Repositories
{
    public class AccesoRepository : IAccesoRepository
    {
        private readonly ClubRecreativoContext _context;

        public AccesoRepository(ClubRecreativoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Acceso>> GetAccesosByClienteIdAsync(int clienteId)
        {
            return await _context.Accesos
                .Include(a => a.Cliente)
                .Where(a => a.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Acceso> GetAccesoByIdAsync(int id)
        {
            return await _context.Accesos.FindAsync(id);
        }

        public async Task AddAsync(Acceso acceso)
        {
            await _context.Accesos.AddAsync(acceso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Acceso acceso)
        {
            _context.Accesos.Update(acceso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var acceso = await GetAccesoByIdAsync(id);
            if (acceso != null)
            {
                _context.Accesos.Remove(acceso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
