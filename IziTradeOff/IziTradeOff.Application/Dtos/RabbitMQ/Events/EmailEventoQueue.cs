using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Application.Dtos.RabbitMQ.Events
{
    public class EmailEventoQueue : Evento
    {
        public string Destinatario { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public EmailEventoQueue(string destinatario, string titulo, string contenido)
        {
            Destinatario=destinatario;
            Titulo=titulo;
            Contenido=contenido;
        }
    }
}
