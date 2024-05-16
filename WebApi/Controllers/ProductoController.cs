using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Aplicacion.BusinessServices;
using WebApi.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoAplicacion _productoAplicacion;
        private readonly ILogger _logger;
        public ProductoController(ILogger<ProductoController> logger, IProductoAplicacion productoAplicacion)
        {
            _logger = logger;
            _productoAplicacion = productoAplicacion;
        }

        // GET: api/values
        [HttpGet("ObtenerTodosProductosd")]
        public IActionResult ObtenerTodosProductos()
        {
            _logger.LogInformation($"Incio - Obtenciendo Todos los Producto");

            var result = _productoAplicacion.ObtenerTodosProductos();

            if (result.IsSuccess)
            {
                _logger.LogInformation($"Resultado: {result.Data.FirstOrDefault()}");

                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        // GET api/values/5
        [HttpGet("ObtenerProductoId/{id}")]
        public IActionResult ObtnerProducto(int id)
        {
            _logger.LogInformation($"Incio - Obtenciendo Producto Id: {id}");

            var result = _productoAplicacion.ObtenerProductoPorId(id);

            if (result.IsSuccess)
            {
                _logger.LogInformation($"Resultado: {result.Data}");

                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Producto entidad)
        {
            _logger.LogInformation($"Incio - Registrando Nuevo Producto");

            var result = _productoAplicacion.CrearProducto(entidad);

            if (result.IsSuccess)
            {
                _logger.LogInformation($"Resultado: {result}");

                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        /*
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

