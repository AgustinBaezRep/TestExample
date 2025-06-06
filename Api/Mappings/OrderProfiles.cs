using Api.Application.Orders.Commands.CrearOrder;
using Api.Domain.Entities;

namespace Api.Mappings
{
    public static class OrderProfiles
    {
        public static CrearOrderCommand ToCrearOrderCommand(this Producto producto)
        {
            return new CrearOrderCommand
            {
                Item = producto,
                TipoCliente = "PorMayor"
            };
        }
    }
}
