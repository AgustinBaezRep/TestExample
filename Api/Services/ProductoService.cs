using Api.Entities;
using Api.Repositories;

namespace Api.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public Producto CrearProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(producto.Nombre));
            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.", nameof(producto.Precio));

            var productoCreado = _repo.Add(producto);

            return productoCreado;
        }

        public IEnumerable<Producto> ListarProductos()
            => _repo.GetAll();
    }
}
