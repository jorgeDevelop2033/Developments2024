
using System.Collections;
using WebApi.Aplicacion;
using WebApi.DbContext_V;
using WebApi.Modelo;

namespace WebApi.Infraestructura.Repositorio
{
    public class ProductoRepositorio : IProducto
    {
        private readonly MyDbContext _myDbContext;

        public ProductoRepositorio(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public bool AgregarProducto(Producto entidad)
        {
            _myDbContext.Add(entidad);

            _myDbContext.SaveChanges();

            //ObtenerTodosProductos();

            return true;
        }

        public ICollection<Producto> ObtenerTodosProductos()
        {

            var data = _myDbContext.Productos.ToList();
            //var eliminado = _myDbContext.Productos.DeleteByKey();


            var entidadElminiar = _myDbContext.Productos.FirstOrDefault();

            //var dataResult = _myDbContext.Remove<Producto>(entidadElminiar!);

            //_myDbContext.ChangeTracker.DetectChanges();
            //Console.WriteLine(_myDbContext.ChangeTracker.DebugView.LongView);


            //_myDbContext.SaveChangesAsync();

            Console.Write("Rescatando Valoresa");

            return data;


            //            throw new NotImplementedException();
        }

        public Producto TraerProductoById(int Id)
        {
            var data = _myDbContext.Productos.FirstOrDefault(x => x.ProductoId == Id);

            return data!;
        }
    }
}


/*
 * 
 * 
 *    public void DeleteBooking(Booking booking)
        {
            var bookedCar = _carDbContext.Cars.FirstOrDefault(c => c.Id == booking.CarId);
            bookedCar.IsBooked = false;

            var bookingToDelete = _carDbContext.Bookings.FirstOrDefault(b => b.Id == booking.Id);

            if(bookingToDelete != null)
            {
                _carDbContext.Bookings.Remove(bookingToDelete);
                _carDbContext.Cars.Update(bookedCar);

                _carDbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_carDbContext.ChangeTracker.DebugView.LongView);

                _carDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The booking to delete cannot be found.");
            }
        }*/