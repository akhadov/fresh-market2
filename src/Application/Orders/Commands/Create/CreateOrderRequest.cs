using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Customers;
using FreshMarket.Domain.Orders;
using MediatR;

namespace FreshMarket.Application.Orders.Commands.Create;
public sealed record CreateOrderRequest(Guid CustomerId) : IRequest;

internal sealed class CreateOrderRequestHandler(
    IRepository<Order> orderRepository,
    IRepository<Customer> customerRepository)
    : IRequestHandler<CreateOrderRequest>
{
    public async Task Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(new CustomerId(request.CustomerId), cancellationToken);

        var order = Order.Create(customer.Id);

        await orderRepository.AddAsync(order, cancellationToken);
    }
}