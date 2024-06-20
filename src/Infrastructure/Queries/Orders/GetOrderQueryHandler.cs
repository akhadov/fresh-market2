using Application.Orders.Queries.GetOrder;
using FreshMarket.Domain.Orders;
using FreshMarket.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Orders;

internal sealed class GetOrderQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetOrderQuery, OrderResponse>
{
    public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orderId = new OrderId(request.OrderId);

        var orderResponse = await context
            .Orders
            .Where(o => o.Id == orderId)
            .Select(o => new OrderResponse(
                o.Id.Value,
                o.CustomerId.Value,
                o.LineItems
                    .Select(li => new LineItemResponse(li.Id.Value, li.Price.Amount))
                    .ToList()))
            .FirstOrDefaultAsync(cancellationToken);

        return orderResponse;
    }
}