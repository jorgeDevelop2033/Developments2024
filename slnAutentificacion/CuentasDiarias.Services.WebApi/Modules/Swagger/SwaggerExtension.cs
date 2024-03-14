using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System.Reflection;

namespace CuentasDiarias.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
             {
                 options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                 {
                     Version = "v1",
                     Title = "Cuentas Diarias  API",
                     Description = "Prueba de la Web API ",
                     TermsOfService = new Uri("https://example.com/terms"),
                     Contact = new OpenApiContact
                     {
                         Name = "Jorge Soto",
                         Url = new Uri("https://example.com/contact")
                     },
                     License = new OpenApiLicense
                     {
                         Name = "Example License",
                         Url = new Uri("https://example.com/license")
                     }
                 });

                 var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));                

                 options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = "Autorizacion",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.Http,
                     Scheme = "Bearer",
                     BearerFormat = "JWT",
                     Name = "Autorizacion",
                     Reference = new OpenApiReference
                     {
                         Id = JwtBearerDefaults.AuthenticationScheme,
                         Type = ReferenceType.SecurityScheme
                     }
                 });

                 options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                {
                     new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"


                    }
                },
                new string[] {}
                     }
                 });
             });

            return services;
        }
    }
}
