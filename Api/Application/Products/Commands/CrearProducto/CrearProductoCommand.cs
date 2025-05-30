using Api.Domain.Entities;
using MediatR;

namespace Api.Application.Products.Commands.CrearProducto;

public class CrearProductoCommand : IRequest<Producto>
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
}
