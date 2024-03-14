using Microsoft.CodeAnalysis.CSharp.Syntax;
using WatchDog;

namespace CuentasDiarias.Services.WebApi.Modules.Watchdog
{
    public static class WatchdogsExtension
    {

        public static IServiceCollection AddWatchDogs(this IServiceCollection services,IConfiguration config)
        {

            services.AddWatchDogServices(opt =>
            {
                opt.SqlDriverOption = WatchDog.src.Enums.WatchDogSqlDriverEnum.MSSQL;
                opt.SetExternalDbConnString = config.GetConnectionString("CadenaConexion");
            });

            return services;
        }
    }
}
