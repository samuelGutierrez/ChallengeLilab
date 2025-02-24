using ClubRecreativo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubRecreativo.Infrastructure.DbContext
{
    public class ClubRecreativoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ClubRecreativoContext(DbContextOptions<ClubRecreativoContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<ValetParking> ValetParking { get; set; }
        public DbSet<UbicacionEstacionamiento> UbicacionesEstacionamiento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Agregar datos iniciales para roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Nombre = "Administrador" },
                new Role { Id = 2, Nombre = "PersonalAutorizado" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
