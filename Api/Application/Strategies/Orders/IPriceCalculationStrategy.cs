using Api.Domain.Entities;

namespace Api.Application.Strategies.Orders;

public interface IPriceCalculationStrategy
{
    decimal CalcularPrecio(Producto producto);
}
