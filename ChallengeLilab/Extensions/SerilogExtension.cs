using Serilog;

namespace ClubRecreativo.Api.Extensions
{
    public static class SerilogExtension
    {
        public static IHostBuilder UseSerilogConfiguration(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((context, config) =>
            {
                config
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                    .WriteTo.Seq("http://localhost:5341");
            });
        }
    }
}
