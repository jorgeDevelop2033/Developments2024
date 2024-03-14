using CuentasDiarias.Application.Interface;
using CuentasDiarias.Application.Main;
using CuentasDiarias.Domain.Core;
using CuentasDiarias.Domain.Interface;
using CuentasDiarias.Domain.Interface.Publicaciones;
using CuentasDiarias.Infrastructure.Data;
using CuentasDiarias.Infrastructure.Interface;
using CuentasDiarias.Infrastructure.Repository;
using CuentasDiarias.Transversal.Common;
using CuentasDiarias.Transversal.Logging;

namespace CuentasDiarias.Services.WebApi.Modules.Injection
{

    public static class InjectionExtensions
    {
        public static void InjectionRegistration(this IServiceCollection services)
        {
            ////siongleton - se crea la primera vez y los demas usan la q se crea
            //scope -
            //transtorio - solo cada vez q se solicita

            services.AddSingleton<DapperContext>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>)); //TypeOf yab que es una clase generica <T>

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddScoped<IRolesApplication, RolesApplication>();
            services.AddScoped<IRolesDomain, RolesDomain>();
            services.AddScoped<IRolesRepository, RolesRepository>();
        }
    }
}
