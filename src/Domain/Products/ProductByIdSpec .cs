using Ardalis.Specification;

namespace FreshMarket.Domain.Products;
public sealed class ProductByIdSpec : SingleResultSpecification<Product>
{
    public ProductByIdSpec(ProductId productId) => Query
        .Where(p => p.Id == productId);
}