using Api.Domain.Entities;

namespace Api.Application.Strategies.Orders
{
    public class VipPriceCalculator : IPriceCalculationStrategy
    {
        private const decimal DescuentoVip = 0.15m; // 15% de descuento para clientes VIP

        public decimal CalcularPrecio(Producto producto)
        {
            var basePrice = producto.Precio;
            var discount = basePrice * DescuentoVip;
            var totalPrice = basePrice - discount;

            return totalPrice;
        }
    }
}
