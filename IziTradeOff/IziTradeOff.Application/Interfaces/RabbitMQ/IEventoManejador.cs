using IziTradeOff.Application.Dtos.RabbitMQ;
using System.Threading.Tasks;

namespace IziTradeOff.Application.Interfaces.RabbitMQ
{
    public interface IEventoManejador<in TEvent> : IEventoManejador where TEvent : Evento
    {
        Task Handle(TEvent @event);
    }
    public interface IEventoManejador
    {

    }
}
