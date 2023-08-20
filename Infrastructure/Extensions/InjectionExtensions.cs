using Application.Interfaces.Repositories.Generic;
using Application.Interfaces.Repositories.UnitOfWorks;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Generic;
using Infrastructure.Repositories.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(SocialMediaContext).Assembly.FullName;

            services.AddDbContext<SocialMediaContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
