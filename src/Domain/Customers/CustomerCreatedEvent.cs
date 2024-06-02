using FreshMarket.Domain.Common.Base;

namespace FreshMarket.Domain.Customers;
public record CustomerCreatedEvent(Customer Customer) : DomainEvent;