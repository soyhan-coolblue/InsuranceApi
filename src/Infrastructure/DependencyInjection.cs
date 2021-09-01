using Insurance.Application.Common.Interfaces;
using Insurance.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Insurance.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomainEventService, DomainEventService>();


            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddTransient<IIdentityService, IdentityService>();

            services.AddRefitClient<IProductApi>()
                .ConfigureHttpClient(client => {
                    client.BaseAddress = new Uri(configuration.GetValue<string>("ProductApi:BaseAddress"));
                });



            return services;
        }
    }
}