using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Customers;
using MediatR;

namespace FreshMarket.Application.Customers.Commands.Create;
public sealed record class CreateCustomerRequest(string Email, string FirstName, string LastName) : IRequest<Guid>;

internal sealed class CreateCustomerRequestHandler(IRepository<Customer> repository) : IRequestHandler<CreateCustomerRequest, Guid>
{
    public async Task<Guid> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        Email email = Email.Create(request.Email);
        var firstName = new FirstName(request.FirstName);
        var lastName = new LastName(request.LastName);

        var customer = Customer.Create(email, firstName, lastName);

        await repository.AddAsync(customer, cancellationToken);

        return customer.Id.Value;
    }
}