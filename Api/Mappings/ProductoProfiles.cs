using Api.Application.Products.Commands.CrearProducto;
using Api.Domain.Entities;

namespace Api.Mappings;

public static class ProductoProfiles
{
    public static Producto ToProductoEntity(this CrearProductoCommand command)
    {
        return new Producto
        {
            Nombre = command.Nombre,
            Precio = command.Precio
        };
    }

    public static CrearProductoCommand ToProductoCommand(this Producto producto)
    {
        return new CrearProductoCommand
        {
            Nombre = producto.Nombre,
            Precio = producto.Precio
        };
    }
}
