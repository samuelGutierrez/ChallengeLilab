using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClubRecreativo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IServicioCliente, ServicioCliente>();
            services.AddScoped<IServicioAcceso, ServicioAcceso>();
            services.AddScoped<IServicioVehiculo, ServicioVehiculo>();
            services.AddScoped<IServicioValetParking, ServicioValetParking>();
            services.AddScoped<IServicioUbicacionEstacionamiento, ServicioUbicacionEstacionamiento>();

            return services;
        }
    }
}
