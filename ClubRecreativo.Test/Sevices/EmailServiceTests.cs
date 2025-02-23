using ClubRecreativo.Infrastructure.Email;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Net.Mail;
using Xunit;

namespace ClubRecreativo.Test.Sevices
{
    public class EmailServiceTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly EmailSender _emailSender;

        public EmailServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();

            // Simular configuración de SMTP
            _configurationMock.Setup(config => config["EmailSettings:SmtpServer"]).Returns("smtp.test.com");
            _configurationMock.Setup(config => config["EmailSettings:Port"]).Returns("587");
            _configurationMock.Setup(config => config["EmailSettings:SenderName"]).Returns("Club Test");
            _configurationMock.Setup(config => config["EmailSettings:SenderEmail"]).Returns("test@example.com");
            _configurationMock.Setup(config => config["EmailSettings:Username"]).Returns("test@example.com");
            _configurationMock.Setup(config => config["EmailSettings:Password"]).Returns("password123");

            _emailSender = new EmailSender(_configurationMock.Object);
        }

        [Fact]
        public async Task EnviarCorreoAsync_DatosValidos_DeberiaEnviarCorreoSinErrores()
        {
            // Arrange
            var destinatario = "cliente@example.com";
            var asunto = "Test de Correo";
            var cuerpo = "<b>Este es un correo de prueba</b>";

            // Act & Assert
            var exception = await Record.ExceptionAsync(() =>
                _emailSender.EnviarCorreoAsync(destinatario, asunto, cuerpo)
            );

            exception.Should().BeNull("El correo debería enviarse sin errores");
        }

        [Fact]
        public async Task EnviarCorreoAsync_ErrorAlEnviar_DeberiaLanzarExcepcion()
        {
            // Arrange: Simulamos un error en la configuración
            _configurationMock.Setup(config => config["EmailSettings:SmtpServer"]).Returns("smtp.incorrecto.com");

            var destinatario = "cliente@example.com";
            var asunto = "Error al Enviar";
            var cuerpo = "Este correo debería fallar";

            // Act
            var exception = await Record.ExceptionAsync(() =>
                _emailSender.EnviarCorreoAsync(destinatario, asunto, cuerpo)
            );

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<SmtpException>();
        }
    }
}
