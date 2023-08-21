using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "Web API",
                Version = "v1",
                Description = "Api de comentarios y posts",
                TermsOfService = new Uri("https://opensource.org/licenses/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "Damian Cisneros",
                    Email = "dacisneros5@hotmail.com",
                    Url = new Uri("https://damiancisneros.tech")
                },
                License = new OpenApiLicense
                {
                    Name = "Sin Licencia",
                    Url = new Uri("https://opensource.org/licenses/")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

            
                
            });

            return services;
        }
    }
}
