using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Business.Services;
using ReceivablesManagement.Business.Validation;

namespace ReceivablesManagement.Business
{
    public static class Configuration
	{
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IReceivablesServices, ReceivablesServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IValidator<ReceivableDTO>, ReceivableDTOValidator>();

            return services;
        }
    }
}

