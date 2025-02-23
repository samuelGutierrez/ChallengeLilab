using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Infrastructure.DbContext;
using ClubRecreativo.Infrastructure.Email;
using ClubRecreativo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClubRecreativo.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de MySQL
            services.AddDbContext<ClubRecreativoContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 0))
                )
            );

            // Inyección de dependencias de los repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAccesoRepository, AccesoRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IValetParkingRepository, ValetParkingRepository>();
            services.AddScoped<IUbicacionEstacionamientoRepository, UbicacionEstacionamientoRepository>();
            services.AddScoped<IEmailService, EmailSender>();

            return services;
        }
    }
}
