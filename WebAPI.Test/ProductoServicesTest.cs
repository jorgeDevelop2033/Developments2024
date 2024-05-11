
using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebApi.Aplicacion;
using WebApi.DbContext_V;
using WebApi.Infraestructura.Repositorio;
using WebApi.Modelo;

namespace WebAPI.Test
{

	public class ProductoServicesTest
	{
		//procesdo logico 
		//cambiar por el dTO
		private IEnumerable<Producto> ObtenerDataPrueba() { 
			A.Configure<Producto>()
				.Fill(x => x.Nombre).AsFirstName()
				.Fill(x => x.ProductoId, () => { return 2; });

			var lista = A.ListOf<Producto>(1);

			return lista;
		}

		//convertiendo en una entidad
		private Mock<MyDbContext> CrearContexto() {
			var dataPrueba = ObtenerDataPrueba().AsQueryable();

			var dbSet = new Mock<DbSet<Producto>>();
			//propiedad q deben tener las entidades entityFramework
			//Crea una entidad
			dbSet.As<IQueryable<Producto>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
			dbSet.As<IQueryable<Producto>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
			dbSet.As<IQueryable<Producto>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
			dbSet.As<IQueryable<Producto>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());


			//se  crean los metodos para soportar que sean asincronos 

			dbSet.As<IAsyncEnumerable<Producto>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
				.Returns(new AsyncEnumerator<Producto>(dataPrueba.GetEnumerator()));


			// se pueden hacer filtros a la entidad productos
			dbSet.As<IQueryable<Producto>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Producto>(dataPrueba.Provider));

			var data = new Mock<MyDbContext>();

			data.Setup(x => x.Productos).Returns(dbSet.Object);

			return data;
		}
	
		[Fact]
		public void GetProductos() 
		{
			System.Diagnostics.Debugger.Launch();
			//12
			/**
			 * 1. EMULAR LA INSTANCIA ENTITY FRAMEWORK -- 
			 *		eMULAR LAS ACCIONES Y EVENTOS DE UN OBJECTOS SE USAN LOS OBJECTOS MOCK
			 *		 MOCK REPRESENTA ELEMENTO DE TU CODIGO 
			 * 
			 */

			//Configuracion MapperTEst
			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MappingTest());
			});


			var mapper = mapConfig.CreateMapper();//Este mapper se deben ir en el constructor de las clases


			var mockReposditorio = CrearContexto();
			//mockMapper

			//instanciar la clase Bussiness y pasaar los mock que se han creados

			ProductoRepositorio consulta = new ProductoRepositorio(mockReposditorio.Object);

			var test = consulta.ObtenerTodosProductos();

			Assert.True(test.Any());

		}

		[Fact]
		public async void GetProductosById() { 
			//
			var mockRepositorio = CrearContexto();

			//le paso el contexto al constructor de repositorio
			ProductoRepositorio consulta = new ProductoRepositorio(mockRepositorio.Object);

			var test = consulta.TraerProductoById(2);

			Assert.NotNull(test);
			Assert.True(test.ProductoId == 2);
		}

		[Fact]
		public async void GuardarProductoEnMemoria()
		{
			//Configuracion de la base de datos en memoria
			var options = new DbContextOptionsBuilder<MyDbContext>()
				.UseInMemoryDatabase(databaseName: "BaseDatosProductosMemoria")
				.Options;

			//Creacion del contexto

			var contexto = new MyDbContext(options);


			ProductoRepositorio repositorio = new ProductoRepositorio(contexto);

			//
			var entidad = new Producto();

			entidad.Nombre = "TEst de producto";
			entidad.precio = 2999;
			entidad.Descripcion = "Datos descripcion";
			entidad.ProductoGuid = Convert.ToString(new Guid());


			var producto = repositorio.AgregarProducto(entidad);

			Assert.True(producto);






		}
	}
}


