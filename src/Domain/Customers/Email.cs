using Ardalis.GuardClauses;

namespace FreshMarket.Domain.Customers;
public sealed record Email
{
    private Email(string value) => Value = value;

    public string Value { get; }

    public static Email Create(string? email)
    {
        //if (email.Split('@').Length != 2)
        //{
        //    return Result.Failure<Email>(EmailErrors.InvalidFormat);
        //}
        Guard.Against.NullOrWhiteSpace(email);

        return new Email(email);
    }
}