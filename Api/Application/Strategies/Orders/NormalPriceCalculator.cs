using Api.Domain.Entities;

namespace Api.Application.Strategies.Orders
{
    public class NormalPriceCalculator : IPriceCalculationStrategy
    {
        public decimal CalcularPrecio(Producto producto)
        {
            return producto.Precio;
        }
    }
}
