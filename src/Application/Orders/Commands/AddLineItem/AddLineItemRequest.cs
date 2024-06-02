using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Orders;
using FreshMarket.Domain.Products;
using MediatR;

namespace FreshMarket.Application.Orders.Commands.AddLineItem;

public sealed record AddLineItemRequest(OrderId OrderId, ProductId ProductId, string Currency, decimal Amount)
    : IRequest;

internal sealed class AddLineItemRequestHandler(
    IRepository<Order> orderRepository,
    IRepository<Product> productRepository)
    : IRequestHandler<AddLineItemRequest>
{
    public async Task Handle(AddLineItemRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.OrderId, cancellationToken);

        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        order.AddLineItem(product.Id, new Money(request.Currency, request.Amount));

        await orderRepository.SaveChangesAsync(cancellationToken);
    }
}