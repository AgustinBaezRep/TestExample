using Api.Entities;

namespace Api.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private static readonly List<Producto> _productos = new();
        private static int _nextId = 1;

        public Producto Add(Producto producto)
        {
            producto.Id = _nextId++;
            _productos.Add(producto);
            return producto;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _productos.ToList();
        }
    }
}
