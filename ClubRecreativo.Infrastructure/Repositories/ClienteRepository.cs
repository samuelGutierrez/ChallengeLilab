using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClubRecreativoContext _context;

        public ClienteRepository(ClubRecreativoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> GetClienteByNombreAsync(string name)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.NombreCompleto.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await GetClienteByIdAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
