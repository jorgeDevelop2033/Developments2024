using APIGastosDiarios.RemoteModelo;

namespace APIGastosDiarios.RemoteInterfaces
{
	public interface IProductosServices
	{
		Task<Response<ProductoRemoto>> ObtenerProductos(int Id);
	}
}
