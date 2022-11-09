using IziTradeOff.Application.Dtos.RabbitMQ.Events;
using IziTradeOff.Application.Interfaces.RabbitMQ;
using IziTradeOff.Application.Interfaces.SendGrid;
using IziTradeOff.ServicesAPI.RabbitMQ;
using IziTradeOff.ServicesAPI.SendGrid;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IziTradeOff.ServicesAPI.Config
{
    public static class RabbitServicesConfig
    {
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitEventBus(sp.GetService<IMediator>(), scopeFactory, configuration);
            });

            //Handlers
            services.AddTransient<EmailEventoManejador>();
            services.AddTransient<IEventoManejador<EmailEventoQueue>, EmailEventoManejador>();

        }

        public static void Config(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();

            //Subscribes
            eventBus.Subscribe<EmailEventoQueue, EmailEventoManejador>();
        }
    }
}
