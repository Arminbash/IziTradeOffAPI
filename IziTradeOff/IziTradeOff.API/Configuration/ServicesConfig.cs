using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IziTradeOff.Application.Interfaces.Services;
using IziTradeOff.Service.Services;
using IziTradeOff.Application.Interfaces.Services.Query;
using IziTradeOff.Service.Query;
using IziTradeOff.Application.Interfaces.Services.Command;
using IziTradeOff.Service.Command;

namespace IziTradeOff.API.Configuration
{
    public static class ServicesConfig
    {
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Services
            services.AddScoped<ITraduccionService, TraduccionService>();
            services.AddScoped<ITipoPersonaService, TipoPersonaService>();
            services.AddScoped<IPersonaService, PersonaService>(); 
            //Querys
            services.AddScoped<ITraductorQuery, TraduccionQuery>();
            services.AddScoped<ILoginQuery, LoginQuery>();
            services.AddScoped<IRolQuery, RolQuery>();
            services.AddScoped<ITipoPersonaQuery, TipoPersonaQuery>();
            services.AddScoped<IPersonaQuery, PersonaQuery>();
            //Commands
            services.AddScoped<ITraductorCommand, TraduccionCommand>();
            services.AddScoped<ILoginCommand, LoginCommand>();
            services.AddScoped<IRolCommand, RolCommand>();
            services.AddScoped<ITipoPersonaCommand,TipoPersonaCommand>();
            services.AddScoped<IPersonaCommand, PersonaCommand>();  
        }
    }
}
