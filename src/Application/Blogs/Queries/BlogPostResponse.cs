using FreshMarket.Domain.Customers;

namespace Application.Blogs.Queries;

public record BlogPostResponse
{
    public Guid BlogPostId { get; init; }

    public Guid CustomerId { get; init; }

    public string Title { get; init; }

    public string ImagePath { get; init; }

    public string Body { get; init; }

    public string BodyOverview { get; init; }
}
