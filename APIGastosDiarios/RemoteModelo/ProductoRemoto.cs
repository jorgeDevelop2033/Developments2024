namespace APIGastosDiarios.RemoteModelo
{
	public class ProductoRemoto
	{
		public int ProductoId { get; set; }
		public string? Nombre { get; set; }
		public string? Descripcion { get; set; }
		public int precio { get; set; }

		public string? ProductoGuid { get; set; }
	}
}
