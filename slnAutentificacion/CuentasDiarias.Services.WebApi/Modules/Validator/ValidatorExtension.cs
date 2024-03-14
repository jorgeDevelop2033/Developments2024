using CuentasDiarias.Application.Validator;

namespace CuentasDiarias.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtension
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDTOValidator>(); //se crea por cada peticion

            return services;
        }
    }
}
