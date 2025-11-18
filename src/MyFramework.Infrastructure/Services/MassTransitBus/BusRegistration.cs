using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Application.Contracts;
using MyFramework.Infrastructure.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services.MassTransitBus
{
    public static class BusRegistration
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
        {
            services.AddMassTransit(x =>
            {
                // Automatically scan and register all consumers in the current assembly
                x.AddConsumers(Assembly.GetExecutingAssembly());

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqSettings.HostName, "/", h =>
                    {
                        h.Username(rabbitMqSettings.UserName);
                        h.Password(rabbitMqSettings.Password);
                    });

                    // Automatically configure endpoints for all discovered consumers
                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService();

            // Our abstraction layer over MassTransit publish
            services.AddScoped<IEventBus, MassTransitEventBus>();

            return services;
        }
    }
}
