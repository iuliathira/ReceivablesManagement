using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReceivablesManagement.Data.Entities;
using ReceivablesManagement.Data.Repositories;

namespace ReceivablesManagement.Data
{
    public static class Configuration
    {
        public static IServiceCollection AddDataConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<ReceivableDbContext>(options => {
                options.UseInMemoryDatabase("ReceivablesDb");
            });

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ReceivableDbContext>();
                dbContext.Database.EnsureCreated();
            }

            services.AddTransient<IReceivablesRepository, ReceivablesRepository>();

            return services;
        }
    }
}

