using FreshMarket.Domain.Orders;
using MediatR;

namespace Application.Orders.Queries.GetOrderSummary;

public sealed record GetOrderSummaryQuery(Guid OrderId) : IRequest<OrderSummary?>;