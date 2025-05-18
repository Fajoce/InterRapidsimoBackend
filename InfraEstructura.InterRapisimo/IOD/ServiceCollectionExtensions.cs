using Domain.IterRapisimo.Interfaces;
using InfraEstructura.InterRapisimo.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraEstructura.InterRapisimo.IOD
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection MyDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("myConection");

            services.AddDbContext<ColegioDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
