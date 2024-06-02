using FreshMarket.Domain.Common.Base;

namespace FreshMarket.Domain.Categories;
public record CategoryCreatedEvent(Category Category) : DomainEvent;
