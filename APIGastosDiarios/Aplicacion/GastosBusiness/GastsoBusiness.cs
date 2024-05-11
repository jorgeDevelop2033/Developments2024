using APIGastosDiarios.Aplicacion.Interfaces;
using APIGastosDiarios.Modelo;
using APIGastosDiarios.RemoteInterfaces;
using APIGastosDiarios.RemoteModelo;
using APIGastosDiarios.RemoteServices;

namespace APIGastosDiarios.Aplicacion.GastosBusiness
{
	public class GastsoBusiness : IGastosBusiness
	{
		private readonly IGastosRepositorio _repositorio;
		private readonly IProductosServices _productosServices;

		public GastsoBusiness(IGastosRepositorio repositorio, IProductosServices productosServices)
		{
			_repositorio = repositorio;
			_productosServices = productosServices;
		}

		public async Task<Response<RegistrosGastos>> RegistrarGastos(RegistrosGastos ent)
		{
			Response<RegistrosGastos> resultado = new Response<RegistrosGastos>();

			//Test

			var prueba = _productosServices.ObtenerProductos(12);
			 
			try
			{
				if (await _repositorio.AgregarGastos(ent))
				{
					resultado.Data = ent;
					resultado.IsSuccess = true;
					resultado.Message = "Operacion con Exito!";
				}

			}
			catch (Exception ex) { 
				resultado.IsSuccess =false;
				resultado.Message = $"Error en la Operacion, message Error: [{ex.Message.ToString()} ]";
			}

			return resultado;
		}
	}
}
