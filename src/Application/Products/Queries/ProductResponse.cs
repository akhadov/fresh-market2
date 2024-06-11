namespace Application.Products.Queries;

public record ProductResponse
{
    public Guid ProductId { get; init; }
    public string Name { get; init; }
    public string Sku { get; init; }
    public string Currency { get; init; }
    public decimal Amount { get; init; }
}
