using Api.Domain.Entities;

namespace Api.Application.Strategies.Orders;

public class WholesalePriceCalculator : IPriceCalculationStrategy
{
    private const decimal DescuentoMayorista = 0.20m; // 20% de descuento para clientes mayoristas
    private const decimal MontoMinimoDeOrden = 1000.00m;

    public decimal CalcularPrecio(Producto producto)
    {
        var basePrice = producto.Precio;
        decimal totalPrice = basePrice;

        if (basePrice >= MontoMinimoDeOrden)
        {
            var discount = basePrice * DescuentoMayorista;
            totalPrice = basePrice - discount;
        }

        return totalPrice;
    }
}
