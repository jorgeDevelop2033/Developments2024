
using CuentasDiarias.Application.Interface;
using CuentasDiarias.Application.Main;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CuentasDiarias.Apliccation.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) //accede al directorio del trabaji
                .AddJsonFile("appsettings.json", true, true) //se agrega el archivoi de configuracion , base de datos etc
                .AddEnvironmentVariables();

            _configuration = builder.Build(); //se agrega la configuracion con el metodo de buid

            //se esta cargando toda la configuracion de la aplicacion

            
            var servicios = new ServiceCollection();



            var app = builder.Build();
            _scopeFactory = servicios.BuildServiceProvider().GetService<IServiceScopeFactory>();
            


        }

        [TestMethod]
        public void Autentificacion_CuandoNoSeEnvianParametros_RetornaMensajeErrorValidator()
        {
           using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            var userName = string.Empty;
            var Password = string.Empty;
            var excepted = "Errores de Validación";


            var result = context.Authenticate(userName, Password);

            var actual = result.Message;

            Assert.AreEqual(excepted, actual);

        }
    }
}