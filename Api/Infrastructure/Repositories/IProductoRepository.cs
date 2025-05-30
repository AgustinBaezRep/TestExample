using Api.Domain.Entities;

namespace Api.Infrastructure.Repositories
{
    public interface IProductoRepository
    {
        Producto Add(Producto producto);
        bool Delete(Producto producto);
        IEnumerable<Producto> GetAll();
    }
}
