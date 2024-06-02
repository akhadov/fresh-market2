using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Categories;
using FreshMarket.Domain.Products;
using MediatR;

namespace FreshMarket.Application.Products.Commands.Update;
public sealed record UpdateProductRequest(ProductId Id, CategoryId CategoryId, string Name, string Sku, decimal Amount, string Currency) : IRequest<Guid>;

internal sealed class UpdateProductRequestHandler(IRepository<Product> repository) : IRequestHandler<UpdateProductRequest, Guid>
{
    public async Task<Guid> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        product.Update(
            request.CategoryId,
            request.Name,
            new Money(request.Currency, request.Amount),
            Sku.Create(request.Sku)!);

        await repository.UpdateAsync(product, cancellationToken);

        return product.Id.Value;
    }
}