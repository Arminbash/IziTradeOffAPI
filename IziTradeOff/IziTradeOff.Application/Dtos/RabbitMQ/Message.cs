using MediatR;

namespace IziTradeOff.Application.Dtos.RabbitMQ
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        public Message()
        {
            MessageType=GetType().Name;
        }
    }
}
