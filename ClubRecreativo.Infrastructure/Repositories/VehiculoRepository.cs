using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ClubRecreativo.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ClubRecreativoContext _context;

        public VehiculoRepository(ClubRecreativoContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo> GetVehiculosByAccesoIdAsync(int accesoId)
        {
            return await _context.Vehiculos
                .Include(v => v.Acceso)
                .Include(v => v.ValetParking)
                .Include(v => v.UbicacionEstacionamiento)
                .Where(v => v.AccesoId == accesoId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosAsync()
        {
            return await _context.Vehiculos
                .Include(v => v.Acceso)
                .Include(v => v.ValetParking)
                .Include(v => v.UbicacionEstacionamiento)
                .ToListAsync();
        }

        public async Task<Vehiculo> GetVehiculoByPlacaAsync(string placa)
        {
            return await _context.Vehiculos.FirstOrDefaultAsync(c => c.Placa.Trim().ToLower() == placa.Trim().ToLower());
        }

        public async Task<Vehiculo> GetVehiculoByIdAsync(int id)
        {
            return await _context.Vehiculos
                .Include(v => v.ValetParking)
                .Include(v => v.UbicacionEstacionamiento)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Vehiculo vehiculo)
        {
            await _context.Vehiculos.AddAsync(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vehiculo = await GetVehiculoByIdAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EstaUbicacionOcupadaAsync(int ubicacionEstacionamientoId)
        {
            return await _context.Vehiculos
                .AnyAsync(v => v.UbicacionEstacionamientoId == ubicacionEstacionamientoId && v.FechaSalida == null);
        }
    }
}
