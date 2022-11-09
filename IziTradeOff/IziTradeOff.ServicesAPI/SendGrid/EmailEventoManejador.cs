using IziTradeOff.Application.Dtos.RabbitMQ.Events;
using IziTradeOff.Application.Dtos.SendGrid;
using IziTradeOff.Application.Interfaces.RabbitMQ;
using IziTradeOff.Application.Interfaces.SendGrid;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IziTradeOff.ServicesAPI.SendGrid
{
    public class EmailEventoManejador : IEventoManejador<EmailEventoQueue>
    {
        private readonly ILogger<EmailEventoManejador> _logger;
        private readonly ISendGridEnviar _sendGridEnviar;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public EmailEventoManejador(ILogger<EmailEventoManejador> logger, ISendGridEnviar sendGridEnviar, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _logger=logger;
            _sendGridEnviar=sendGridEnviar;
            _configuration=configuration;
        }

        public EmailEventoManejador()
        {
        }

        public async Task Handle(EmailEventoQueue @event)
        {
            _logger.LogInformation($"Este es el titulo {@event.Titulo}");

            var objData = new SendGridData();
            objData.Titulo = @event.Titulo;
            objData.Contenido = @event.Contenido;
            objData.EmailDestinatario = @event.Destinatario;
            objData.NombreDestinatario = @event.Destinatario;
            objData.SendGridApiKey = _configuration["SendGrid:ApiKey"];

            var resultado = await _sendGridEnviar.EnviarEmail(objData);

            if (resultado.resultado)
            {
                await Task.CompletedTask;

                return;
            }
        }
    }
}
