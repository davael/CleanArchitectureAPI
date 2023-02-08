using Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClubesContext>(options => options.UseSqlServer(configuration.GetConnectionString("Connection")));
            return services;
        }
    }
}
