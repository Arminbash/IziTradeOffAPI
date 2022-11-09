using IziTradeOff.Application.Dtos.RabbitMQ.Events;
using IziTradeOff.Application.Interfaces.RabbitMQ;
using IziTradeOff.Application.Interfaces.SendGrid;
using IziTradeOff.ServicesAPI.Config;
using IziTradeOff.ServicesAPI.RabbitMQ;
using IziTradeOff.ServicesAPI.SendGrid;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IziTradeOff.ServicesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            RabbitServicesConfig.Config(services, Configuration);

            services.AddSingleton<ISendGridEnviar, SendGridEnviar>();

            services.AddMediatR(typeof(ServicesAPI.SendGrid.EmailEventoManejador).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            RabbitServicesConfig.Config(app, env);
        }
    }
}
