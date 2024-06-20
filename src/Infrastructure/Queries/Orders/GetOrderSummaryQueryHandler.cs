using Application.Orders.Queries.GetOrderSummary;
using FreshMarket.Domain.Orders;
using FreshMarket.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Orders;

internal sealed class GetOrderSummaryQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetOrderSummaryQuery, OrderSummary>
{
    public async Task<OrderSummary> Handle(GetOrderSummaryQuery request, CancellationToken cancellationToken)
    {
        return await context.OrderSummaries
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
    }
}