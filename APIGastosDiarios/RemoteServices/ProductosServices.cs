using APIGastosDiarios.RemoteInterfaces;
using APIGastosDiarios.RemoteModelo;
using System.Text.Json;

namespace APIGastosDiarios.RemoteServices
{
	public class ProductosServices : IProductosServices
	{
		private readonly IHttpClientFactory _httpClient;
		private readonly ILogger<ProductosServices> _logger;

		public ProductosServices(IHttpClientFactory httpClient, ILogger<ProductosServices> logger)
		{
			_httpClient = httpClient;
			_logger = logger;
		}

		public async Task<Response<ProductoRemoto>> ObtenerProductos(int Id)
		{
			var response = new Response<ProductoRemoto>();	
			try
			{

				var cliente = _httpClient.CreateClient("Productos");
				var resultado =  await cliente.GetAsync($"api/Producto/ObtenerProductoId/{Id}");

				if (resultado.IsSuccessStatusCode)
				{
					var contendio = await resultado.Content.ReadAsStreamAsync();
					var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

					var result = JsonSerializer.Deserialize<Response<ProductoRemoto>>(contendio, options);


					response.IsSuccess = true;
					response.Data = result.Data;
					response.Message = "Operacion con Existo";
				}


				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
