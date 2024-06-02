using Ardalis.GuardClauses;

namespace FreshMarket.Domain.Customers;
public sealed record LastName
{
    public LastName(string? value)
    {
        Guard.Against.NullOrWhiteSpace(value);

        Value = value;
    }

    public string Value { get; }
}