using FreshMarket.Domain.Common.Base;

namespace FreshMarket.Domain.Common.Interfaces;

public interface IAggregateRoot
{
    IReadOnlyList<DomainEvent> DomainEvents { get; }

    void AddDomainEvent(DomainEvent domainEvent);

    void RemoveDomainEvent(DomainEvent domainEvent);

    void ClearDomainEvents();
}