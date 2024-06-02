using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Products;
using MediatR;

namespace FreshMarket.Application.Products.Commands.Delete;
public sealed record DeleteProductRequest(Guid ProductId) : IRequest<Guid>;

internal sealed class DeleteProductHandler(IRepository<Product> repository)
    : IRequestHandler<DeleteProductRequest, Guid>
{
    public async Task<Guid> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(new ProductId(request.ProductId), cancellationToken);

        await repository.DeleteAsync(product, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);

        return product.Id.Value;
    }
}