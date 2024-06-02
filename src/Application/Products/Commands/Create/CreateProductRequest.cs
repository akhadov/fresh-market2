using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Categories;
using FreshMarket.Domain.Products;
using MediatR;

namespace FreshMarket.Application.Products.Commands.Create;
public sealed record CreateProductRequest(string Name, string Sku, decimal Amount, string Currency, Guid CategoryId)
    : IRequest<Guid>;

internal sealed class CreateProductRequestHandler(IRepository<Product> repository)
    : IRequestHandler<CreateProductRequest, Guid>
{
    public async Task<Guid> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var categoryId = new CategoryId(request.CategoryId);

        var price = new Money(request.Currency, request.Amount);

        var sku = Sku.Create(request.Sku);

        var product = Product.Create(request.Name, price, sku!, categoryId);

        await repository.AddAsync(product, cancellationToken);

        return product.Id.Value;
    }
}