using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Orders;
using MediatR;


namespace FreshMarket.Application.Orders.Commands.RemoveLineItem;

public sealed record RemoveLineItemRequest(Guid OrderId, Guid LineItemId) : IRequest<Guid>;

internal sealed class RemoveLineItemHandler(IRepository<Order> repository) : IRequestHandler<RemoveLineItemRequest, Guid>
{
    public async Task<Guid> Handle(RemoveLineItemRequest request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(new OrderId(request.OrderId), cancellationToken);

        order.RemoveLineItem(new LineItemId(request.LineItemId));

        await repository.DeleteAsync(order, cancellationToken);

        return order.Id.Value;
    }
}