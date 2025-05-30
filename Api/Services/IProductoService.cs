using Api.Entities;

namespace Api.Services
{
    public interface IProductoService
    {
        Producto CrearProducto(Producto producto);
        bool EliminarProducto(int id);
        IEnumerable<Producto> ListarProductos();
    }
}
