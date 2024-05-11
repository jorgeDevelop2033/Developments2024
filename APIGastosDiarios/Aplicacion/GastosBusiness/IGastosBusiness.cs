using APIGastosDiarios.Modelo;

namespace APIGastosDiarios.Aplicacion.GastosBusiness
{
	public interface IGastosBusiness
	{

		public Task<Response<RegistrosGastos>> RegistrarGastos(RegistrosGastos ent);


	}
}
