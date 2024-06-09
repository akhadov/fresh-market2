namespace FreshMarket.Domain.Common.Base;
public abstract class Entity<TId> : AuditableEntity
{
    public TId Id { get; set; } = default!;
}
