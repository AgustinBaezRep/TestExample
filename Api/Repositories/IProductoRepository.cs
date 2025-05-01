using Api.Entities;

namespace Api.Repositories
{
    public interface IProductoRepository
    {
        Producto Add(Producto producto);
        IEnumerable<Producto> GetAll();
    }
}
