using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System;
using IziTradeOff.Application.Interfaces.SendGrid;
using IziTradeOff.Application.Dtos.SendGrid;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace IziTradeOff.ServicesAPI.SendGrid
{
    public class SendGridEnviar : ISendGridEnviar
    {
        public async Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data)
        {
            try
            {
                var sendGridCliente = new SendGridClient(data.SendGridApiKey);
                var destinatario = new EmailAddress(data.EmailDestinatario, data.NombreDestinatario);
                var sender = new EmailAddress(Environment.GetEnvironmentVariable("SendGrid:Email"), Environment.GetEnvironmentVariable("SendGrid:UserName"));
                var contenidoMensaje = data.Contenido;

                var objMensaje = MailHelper.CreateSingleEmail(sender, destinatario, data.Titulo, contenidoMensaje, contenidoMensaje);

                await sendGridCliente.SendEmailAsync(objMensaje);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
