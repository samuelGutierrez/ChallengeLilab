using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClubRecreativoContext _context;

        public UsuarioRepository(ClubRecreativoContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> GetUsuarioPorCredencialesAsync(string usuario, string contrasena)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Usuario == usuario && u.Contrasena == contrasena);
        }

        public async Task<IEnumerable<Usuarios>> GetUsuariosAsync()
        {
            return await _context.Usuarios.Include(u => u.Rol).ToListAsync();
        }

        public async Task<Usuarios> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
