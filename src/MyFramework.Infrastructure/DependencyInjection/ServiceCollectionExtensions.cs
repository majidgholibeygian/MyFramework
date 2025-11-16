using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Application.Interfaces;
using MyFramework.Infrastructure.Persistence;
using MyFramework.Infrastructure.Repositories;
using MyFramework.Infrastructure.Services;
using System;

namespace MyFramework.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Fix: Use IConfigurationSection, not IConfiguration, for Configure<T> 
            services.Configure<MinioSettings>(configuration.GetSection("Minio"));

            var conn = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection required");

            services.AddDbContext<MyFrameworkDbContext>(options =>
                options.UseSqlServer(conn));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddSingleton<IMinioService, MinioService>();

            return services;
        }
    }
}
