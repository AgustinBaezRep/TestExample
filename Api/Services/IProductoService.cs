using Api.Entities;

namespace Api.Services
{
    public interface IProductoService
    {
        Producto CrearProducto(Producto producto);
        IEnumerable<Producto> ListarProductos();
    }
}
