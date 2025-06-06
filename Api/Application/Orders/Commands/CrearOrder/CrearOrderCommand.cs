using Api.Domain.Entities;
using MediatR;

namespace Api.Application.Orders.Commands.CrearOrder;

public sealed class CrearOrderCommand : IRequest<bool>
{
    public Producto Item { get; set; } = new Producto();
    public string TipoCliente { get; set; } = string.Empty;
}
