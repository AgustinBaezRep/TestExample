using Api.Domain.Entities;
using Api.Mappings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public ActionResult<Producto> Crear([FromBody] Producto producto)
        {
            try
            {
                var orderCommand = producto.ToCrearOrderCommand();
                var creado = _sender.Send(orderCommand).Result;

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
