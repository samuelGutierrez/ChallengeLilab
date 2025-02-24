using ClubRecreativo.Extensions;
using ClubRecreativo.Application;
using ClubRecreativo.Infrastructure.DependencyInjection;
using ClubRecreativo.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de Serilog
builder.Host.UseSerilogConfiguration();

// Configuraci�n de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
