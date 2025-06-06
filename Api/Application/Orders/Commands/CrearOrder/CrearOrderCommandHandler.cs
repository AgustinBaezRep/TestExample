using Api.Application.Strategies.Orders;
using MediatR;

namespace Api.Application.Orders.Commands.CrearOrder
{
    public sealed class CrearOrderCommandHandler : IRequestHandler<CrearOrderCommand, bool>
    {
        public Task<bool> Handle(CrearOrderCommand request, CancellationToken cancellationToken)
        {
            IPriceCalculationStrategy precioStrategy = request.TipoCliente switch
            {
                "Vip" => new VipPriceCalculator(),
                "PorMayor" => new WholesalePriceCalculator(),
                _ => new NormalPriceCalculator()
            };

            var precioCalculado = precioStrategy.CalcularPrecio(request.Item);

            return Task.FromResult(true);
        }
    }
}
