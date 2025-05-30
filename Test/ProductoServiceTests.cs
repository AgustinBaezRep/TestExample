using Api.Application.Services;
using Api.Domain.Entities;
using Api.Infrastructure.Repositories;
using Moq;

namespace Test
{
    public class ProductoServiceTests
    {
        private readonly Mock<IProductoRepository> _repoMock;
        private readonly ProductoService _service;

        public ProductoServiceTests()
        {
            _repoMock = new Mock<IProductoRepository>();
            _service = new ProductoService(_repoMock.Object);
        }

        [Fact]
        public void CrearProducto_ProductoConNombreYPrecioValido_RetornaProductoCreado()
        {
            // Arrange
            var producto = new Producto { Nombre = "Test", Precio = 10.0m };

            _repoMock.Setup(r => r.Add(producto)).Returns(producto);

            // Act
            var resultado = _service.CrearProducto(producto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Test", resultado.Nombre);
            Assert.Equal(10.0m, resultado.Precio);
        }
    }
}
