using System;

namespace IziTradeOff.Application.Dtos.RabbitMQ
{
    public abstract class Evento
    {
        public DateTime Timestamp { get; protected set; }

        protected Evento()
        {
            Timestamp = DateTime.Now;
        }
    }
}
