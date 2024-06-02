using FreshMarket.Domain.Common.Base;

namespace FreshMarket.Domain.Orders;
public record LineItemRemovedEvent(LineItemId LineItemId, OrderId OrderId) : DomainEvent
{
    public static LineItemRemovedEvent Remove(LineItemId lineItemId, OrderId orderId) => new(lineItemId, orderId);
}