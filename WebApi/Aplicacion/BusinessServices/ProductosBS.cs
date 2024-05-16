using System;
using WebApi.DbContext_V;
using WebApi.Infraestructura.Repositorio;
using WebApi.Modelo;

namespace WebApi.Aplicacion.BusinessServices
{
    public class ProductosBS : IProductoAplicacion
    {
        private readonly IProducto _producto;
        //OJO Q FALTA MAPPER

        public ProductosBS(IProducto productoInterface)
        {
            _producto = productoInterface;
        }

        public Response<Producto> CrearProducto(Producto producto)
        {
            var response = new Response<Producto>();

            try
            {
                var productoOK = _producto.AgregarProducto(producto);

                response.Data = producto;
                response.IsSuccess = true;
                response.Message = "Operacion Exitosa.";
            }
            catch (InvalidOperationException exOpe)
            {
                response.IsSuccess = false;
                response.Message = $"Operacion Fallida Error: {exOpe.Message.ToString()}";
            }

            return response;
        }

        public Response<IEnumerable<Producto>> ObtenerTodosProductos()
        {
            var response = new Response<IEnumerable<Producto>>();

            try
            {
                var listaProductos = _producto.ObtenerTodosProductos();

                response.Data = listaProductos;
                response.IsSuccess = true;
                response.Message = "Operacion Exitosa.";
            }
            catch (InvalidOperationException exOpe)
            {
                response.IsSuccess = false;
                response.Message = $"Operacion Fallida Error: {exOpe.Message.ToString()}";
            }

            return response;
        }

        public Response<Producto> ObtenerProductoPorId(int Id)
        {
            var response = new Response<Producto>();

            try
            {
                var producto = _producto.TraerProductoById(Id);

                response.Data = producto;
                response.IsSuccess = true;
                response.Message = "Operacion Exitosa.";
            }
            catch (InvalidOperationException exOpe)
            {
                response.IsSuccess = false;
                response.Message = $"Operacion Fallida Error: {exOpe.Message.ToString()}";
            }

            return response;
        }
    }
}

