using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using CuentasDiarias.Services.WebApi.Controllers;
using System.ServiceProcess;

namespace CuentasDiarias.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtension 
    {
        public static IServiceCollection AddHelthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("CadenaConexion"), tags: new[] { "databases" });
            services.AddHealthChecks().AddCheck(".ss", new ServicesWindowsHealthCheck("MSSQLSERVER"), HealthStatus.Healthy, tags: new string[] { "s" });
                
            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(1);
                opt.SetHeaderText("Estados Aplicaciones Cuentas Personasles ");
                opt.AddHealthCheckEndpoint(name: "API", uri: "http://localhost:53866/healthcheck");
                opt.AddWebhookNotification("webhook1", uri: "/notify", payload: "{...}");
            }).AddInMemoryStorage();
            
            //

            return services;
        }
    }
}
public class ServicesWindowsHealthCheck : IHealthCheck
{
    string NameService { get; } = "MSSQLSERVER";
    public ServicesWindowsHealthCheck(string nameService)
    {
        NameService = nameService;
    }

    public ServicesWindowsHealthCheck()
    {
    }
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        string estado = "";
        try
        {
            ServiceController sc = new ServiceController(NameService);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    estado = "Running";
                    return Task.FromResult(
                    HealthCheckResult.Healthy($"Servicio OK! {estado}"));
                    break;
                case ServiceControllerStatus.Stopped:
                    estado = "Stopped";
                    return Task.FromResult(
                    HealthCheckResult.Unhealthy($"El servicio {NameService} esta {estado}"));
                    break;
                case ServiceControllerStatus.Paused:
                    estado = "Paused";
                    return Task.FromResult(
                    HealthCheckResult.Unhealthy($"El servicio {NameService} esta {estado}"));
                    break;
                case ServiceControllerStatus.StopPending:
                    estado = "Stopping";
                    return Task.FromResult(
                    HealthCheckResult.Unhealthy($"El servicio {NameService} esta {estado}"));
                    break;
                case ServiceControllerStatus.StartPending:
                    estado = "Starting";
                    return Task.FromResult(
                    HealthCheckResult.Healthy($"El servicio {NameService} esta {estado}"));
                    break;
                default:
                    return Task.FromResult(
                    HealthCheckResult.Unhealthy($"Servicio OK! {estado}"));

                    break;
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult(
                   HealthCheckResult.Unhealthy($"El servicio {NameService} esta {estado}"));
        }
    }
}