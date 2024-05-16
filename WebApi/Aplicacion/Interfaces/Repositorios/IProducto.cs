using System.Collections;
using WebApi.Modelo;

namespace WebApi.Aplicacion
{
    public interface IProducto
    {
        //Cambiarlo por DTO y usar el Mapper
        public bool AgregarProducto(Producto entidad);

        public ICollection<Producto> ObtenerTodosProductos();

        public Producto TraerProductoById(int Id);

    }
}
