using MediatR;

namespace Application.Orders.Queries.GetOrder;

public sealed record GetOrderQuery(Guid OrderId) : IRequest<OrderResponse>;