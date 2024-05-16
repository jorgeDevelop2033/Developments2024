using APIGastosDiarios.Aplicacion.GastosBusiness;
using APIGastosDiarios.Modelo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIGastosDiarios.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistrosGastosController : ControllerBase
	{
		private readonly ILogger<RegistrosGastosController> _logger;
		private readonly IGastosBusiness _gastosBusiness;
		public RegistrosGastosController(ILogger<RegistrosGastosController> logger, IGastosBusiness gastosBusiness) 
		{ 
			_gastosBusiness = gastosBusiness;
			_logger = logger;

		}
		// GET: api/<RegistrosGastosController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<RegistrosGastosController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<RegistrosGastosController>
		[HttpPost]
		public void Post([FromBody] RegistrosGastos entidad)
		{
			try
			{ 

			 _gastosBusiness.RegistrarGastos(entidad);

			}catch (Exception ex) 
			{
				
			}
		}

		// PUT api/<RegistrosGastosController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<RegistrosGastosController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
