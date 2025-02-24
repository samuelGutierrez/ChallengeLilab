using ClubRecreativo.Application.DTOs.Acceso;
using ClubRecreativo.Application.Interfaces;
using ClubRecreativo.Domain.Entities;
using ClubRecreativo.Domain.Interfaces;
using ClubRecreativo.Shared.Exceptions;

namespace ClubRecreativo.Application.Services
{
    public class ServicioAcceso : IServicioAcceso
    {
        private readonly IAccesoRepository _accesoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmailService _emailService;
        private readonly IVehiculoRepository _vehiculoRepository;

        public ServicioAcceso(IAccesoRepository accesoRepository, IClienteRepository clienteRepository, IEmailService emailService, IVehiculoRepository vehiculoRepository)
        {
            _accesoRepository = accesoRepository;
            _clienteRepository = clienteRepository;
            _emailService = emailService;
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<Acceso>> ObtenerAccesosPorClienteAsync(int clienteId)
        {
            return await _accesoRepository.GetAccesosByClienteIdAsync(clienteId);
        }

        public async Task RegistrarEntradaAsync(EntradaDto dto)
        {
            // Verificar si la ubicación está libre
            var ubicacionOcupada = await _vehiculoRepository.EstaUbicacionOcupadaAsync(dto.UbicacionEstacionamientoId);
            if (ubicacionOcupada)
            {
                throw new BusinessException($"La ubicación de estacionamiento con ID {dto.UbicacionEstacionamientoId} se encuentra ocupada.");
            }

            // Verificar si el cliente existe por nombre
            var cliente = await _clienteRepository.GetClienteByNombreAsync(dto.NombreCliente);
            if (cliente == null)
            {
                cliente = new Cliente
                {
                    NombreCompleto = dto.NombreCliente
                };
                await _clienteRepository.AddAsync(cliente);
            }

            // Registrar el acceso
            var acceso = new Acceso
            {
                ClienteId = cliente.Id,
                FechaEntrada = DateTime.UtcNow
            };

            await _accesoRepository.AddAsync(acceso);

            var vehiculo = await _vehiculoRepository.GetVehiculoByPlacaAsync(dto.Placa);

            if (vehiculo == null)
            {
                vehiculo = new Vehiculo
                {
                    Marca = dto.Marca,
                    Modelo = dto.Modelo,
                    Placa = dto.Placa,
                    AccesoId = acceso.Id,
                    ValetParkingId = dto.ValetParkingId,
                    UbicacionEstacionamientoId = dto.UbicacionEstacionamientoId,
                    FechaEntrada = DateTime.UtcNow
                };
                await _vehiculoRepository.AddAsync(vehiculo);
            }
        }

        public async Task RegistrarSalidaAsync(int accesoId)
        {
            var acceso = await _accesoRepository.GetAccesoByIdAsync(accesoId);

            if (acceso == null)
                throw new NotFoundException($"El acceso con ID {accesoId} no fue encontrado.");

            if (acceso.FechaSalida != null)
                throw new BusinessException("La salida ya ha sido registrada para este acceso.");

            acceso.FechaSalida = DateTime.UtcNow;
            await _accesoRepository.UpdateAsync(acceso);

            var vehiculo = await _vehiculoRepository.GetVehiculosByAccesoIdAsync(acceso.Id);
            if (vehiculo != null && vehiculo.FechaSalida == null)
            {
                vehiculo.FechaSalida = DateTime.UtcNow;
                await _vehiculoRepository.UpdateAsync(vehiculo);
            }

            var cliente = await _clienteRepository.GetClienteByIdAsync(acceso.ClienteId);
            if (cliente != null)
            {
                var asunto = "Gracias por tu visita al Club Recreativo";
                var cuerpo = $"Hola {cliente.NombreCompleto},<br><br>" +
                             $"Gracias por tu visita. Aquí están los detalles de tu acceso:<br>" +
                             $"<b>Hora de entrada:</b> {acceso.FechaEntrada}<br>" +
                             $"<b>Hora de salida:</b> {acceso.FechaSalida}<br><br>" +
                             $"¡Esperamos verte pronto!";

                await _emailService.EnviarCorreoAsync(cliente.Email, asunto, cuerpo);
            }
        }
    }
}
