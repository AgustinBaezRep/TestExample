using Api.Entities;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Producto> Crear([FromBody] Producto producto)
        {
            try
            {
                var creado = _service.CrearProducto(producto);
                return CreatedAtAction(nameof(ObtenerTodos), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> ObtenerTodos()
            => Ok(_service.ListarProductos());
    }
}
