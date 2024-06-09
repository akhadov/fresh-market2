using Domain.Blogs;
using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Customers;
using MediatR;

namespace Application.Blogs.Commands.CreateBlogPost;

public sealed record CreateBlogPostRequest(Guid CustomerId, string Title, string ImagePath, string Body, string BodyOverview)
    : IRequest<Guid>;

internal sealed class CreateBlogPostRequestHandler(IRepository<BlogPost> blogPostRepository, IRepository<Customer> customerRepository)
    : IRequestHandler<CreateBlogPostRequest, Guid>
{
    public async Task<Guid> Handle(CreateBlogPostRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(new CustomerId(request.CustomerId), cancellationToken);

        var blogPost = BlogPost.Create(customer.Id, request.Title, request.ImagePath, request.Body, request.BodyOverview);

        await blogPostRepository.AddAsync(blogPost, cancellationToken);

        return blogPost.Id.Value;
    }
}
