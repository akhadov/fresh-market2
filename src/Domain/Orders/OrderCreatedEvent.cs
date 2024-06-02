using FreshMarket.Domain.Common.Base;
using FreshMarket.Domain.Customers;

namespace FreshMarket.Domain.Orders;
public record OrderCreatedEvent(OrderId OrderId, CustomerId CustomerId) : DomainEvent
{
    public static OrderCreatedEvent Create(Order order) => new(order.Id, order.CustomerId);
}