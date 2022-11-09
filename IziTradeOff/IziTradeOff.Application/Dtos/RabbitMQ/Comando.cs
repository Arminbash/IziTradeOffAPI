using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Application.Dtos.RabbitMQ
{
    public abstract class Comando : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Comando()
        {
            Timestamp = DateTime.Now;
        }
    }
}
