using Ardalis.GuardClauses;

namespace FreshMarket.Domain.Customers;
public sealed record FirstName
{
    public FirstName(string? value)
    {
        Guard.Against.NullOrWhiteSpace(value);

        Value = value;
    }

    public string Value { get; }
}