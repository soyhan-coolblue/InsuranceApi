using AutoMapper;
using Insurance.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Insurance.Application.Common.Interfaces;
using Insurance.Application.Insurance.Implementations;

namespace Insurance.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddScoped<IProductInsuranceBuilder, ProductInsuranceBuilder>();
            services.AddScoped<IOrderBuilder, OrderBuilder>();
            services.AddSingleton<IProductInsurance, ProductLessThan500>();
            services.AddSingleton<IProductInsurance, ProductBetween500To2000>();

            return services;
        }
    }
}
