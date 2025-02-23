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

        public ServicioAcceso(IAccesoRepository accesoRepository, IClienteRepository clienteRepository, IEmailService emailService)
        {
            _accesoRepository = accesoRepository;
            _clienteRepository = clienteRepository;
            _emailService = emailService;
        }

        public async Task<IEnumerable<Acceso>> ObtenerAccesosPorClienteAsync(int clienteId)
        {
            return await _accesoRepository.GetAccesosByClienteIdAsync(clienteId);
        }

        public async Task RegistrarEntradaAsync(Acceso acceso)
        {
            acceso.FechaEntrada = DateTime.UtcNow;
            await _accesoRepository.AddAsync(acceso);
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
