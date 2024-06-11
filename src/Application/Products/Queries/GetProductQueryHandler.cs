using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Products;
using MediatR;

namespace Application.Products.Queries;

internal sealed class GetProductQueryHandler(IRepository<Product> repository)
    : IRequestHandler<GetProductQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(new ProductId(request.ProductId), cancellationToken);

        var productResponse = new ProductResponse
        {
            ProductId = product.Id.Value,
            Name = product.Name,
            Sku = product.Sku.Value,
            Currency = product.Price.Currency,
            Amount = product.Price.Amount
        };

        return productResponse;
    }
}
