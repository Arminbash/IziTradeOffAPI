using IziTradeOff.Application.Dtos.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading.Tasks;

namespace IziTradeOff.Application.Interfaces.RabbitMQ
{
    public interface IRabbitEventBus
    {
        Task EnviarComando<T>(T comando) where T : Comando;

        void Publish<T>(T @event) where T : Evento;

        void Subscribe<T, TH>() where T : Evento
                                where TH : IEventoManejador<T>;
    }
}
