using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Instinct.Booking.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi (this IServiceCollection services)
        {
            #region Swagger Configuration
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Instict Booking API",
                    Description = "Administración de APIs para booking app"
                });
                

                #region Swagger Security
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese un token válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Agrego autorizacion a los endpoints en swagger, tanto globalmente como individualmente
                options.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string []{}
                    }
                });
                #endregion

                #region Swagger XML Comments
                // ruta de archivo documentado
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,fileName));
                #endregion
            }
            );
            #endregion

            return services;
        }
    }
}
