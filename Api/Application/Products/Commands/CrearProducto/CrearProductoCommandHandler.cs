using Api.Domain.Entities;
using Api.Infrastructure.Repositories;
using Api.Mappings;
using MediatR;

namespace Api.Application.Products.Commands.CrearProducto;

public sealed class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, Producto>
{
    private readonly IProductoRepository _repository;

    public CrearProductoCommandHandler(IProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Producto> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));
        if (string.IsNullOrWhiteSpace(request.Nombre))
            throw new ArgumentException("El nombre es obligatorio.", nameof(request.Nombre));
        if (request.Precio <= 0)
            throw new ArgumentException("El precio debe ser mayor que cero.", nameof(request.Precio));

        var producto = request.ToProductoEntity();

        var productoCreado = _repository.Add(producto);

        return productoCreado;
    }
}
