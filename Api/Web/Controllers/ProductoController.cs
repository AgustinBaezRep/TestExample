using Api.Application.Services;
using Api.Domain.Entities;
using Api.Mappings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly ISender _sender;

        public ProductosController(IProductoService service
            , ISender sender)
        {
            _service = service;
            _sender = sender;
        }

        [HttpPost]
        public ActionResult<Producto> Crear([FromBody] Producto producto)
        {
            try
            {
                var productoCommand = producto.ToProductoCommand();
                var creado = _sender.Send(productoCommand).Result;

                return CreatedAtAction(nameof(ObtenerTodos), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Eliminar([FromRoute] int id)
        {
            try
            {
                var eliminado = _service.EliminarProducto(id);
                return NoContent();
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
