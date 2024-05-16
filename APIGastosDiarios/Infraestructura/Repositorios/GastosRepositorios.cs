using APIGastosDiarios.Aplicacion.GastosBusiness;
using APIGastosDiarios.Aplicacion.Interfaces;
using APIGastosDiarios.Modelo;

namespace APIGastosDiarios.Infraestructura.Repositorios
{
	public class GastosRepositorios : IGastosRepositorio
	{

		private readonly dbContext _productos;
		private readonly ILogger<GastosRepositorios> _logger;

		public GastosRepositorios(ILogger<GastosRepositorios> logger,dbContext productos) 
		{
			_productos = productos;
			_logger = logger;
		}

		public async Task<bool> AgregarGastos(RegistrosGastos entidad)
		{
			_logger.LogInformation("Inicinado Ingreso <Agregar Gastos");

			try
			{
				await _productos.AddAsync(entidad);

			    _productos.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error en el metodo: Error ==> [{ex.Message.ToString()}]");	
			}

			return true;
		}

		public async Task<IEnumerable<RegistrosGastos>> TraerGastosPorFecha(DateTime fecha)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<RegistrosGastos>> TraerTodosGastos()
		{
			throw new NotImplementedException();
		}
	}
}
