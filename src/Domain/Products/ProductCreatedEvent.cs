using FreshMarket.Domain.Common.Base;

namespace FreshMarket.Domain.Products;
public record ProductCreatedEvent(Product Product) : DomainEvent;