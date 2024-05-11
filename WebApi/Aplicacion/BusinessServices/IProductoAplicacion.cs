using System;
using WebApi.Modelo;

namespace WebApi.Aplicacion.BusinessServices
{
    public interface IProductoAplicacion
    {
        public Response<Producto> CrearProducto(Producto producto);
        public Response<IEnumerable<Producto>> ObtenerTodosProductos();
        public Response<Producto> ObtenerProductoPorId(int Id);

    }
}

