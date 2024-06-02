using Ardalis.Specification;

namespace FreshMarket.Domain.Orders;
public sealed class OrderByIdSpec : SingleResultSpecification<Order>
{
    public OrderByIdSpec(OrderId orderId) => Query
        .Where(o => o.Id == orderId);
}