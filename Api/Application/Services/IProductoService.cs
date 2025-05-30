using Api.Domain.Entities;

namespace Api.Application.Services
{
    public interface IProductoService
    {
        Producto CrearProducto(Producto producto);
        bool EliminarProducto(int id);
        IEnumerable<Producto> ListarProductos();
    }
}
