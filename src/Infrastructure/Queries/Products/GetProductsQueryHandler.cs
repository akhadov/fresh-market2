using Application.Common.Models;
using Application.Products.Queries;
using FreshMarket.Domain.Products;
using FreshMarket.Infrastructure.Persistence;
using MediatR;

namespace Infrastructure.Queries.Products;

internal sealed class GetProductsQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetProductsQuery, PagedList<ProductResponse>>
{
    public async Task<PagedList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProductResponse> productsQuery = context.Products
                .Select(p => new ProductResponse
                {
                    ProductId = p.Id.Value,
                    Name = p.Name,
                    Sku = p.Sku.Value,
                    Currency = p.Price.Currency,
                    Amount = p.Price.Amount
                });

        var products = await PagedList<ProductResponse>.CreateAsync(productsQuery, request.Page, request.PageSize);

        return products;
    }
}