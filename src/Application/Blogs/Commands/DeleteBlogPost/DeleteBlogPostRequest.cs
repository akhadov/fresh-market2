using Domain.Blogs;
using FreshMarket.Application.Common.Interfaces;
using MediatR;

namespace Application.Blogs.Commands.DeleteBlogPost;

public sealed record DeleteBlogPostRequest(Guid BlogPostId) : IRequest;

internal sealed class DeleteBlogPostRequestHandler(IRepository<BlogPost> repository)
    : IRequestHandler<DeleteBlogPostRequest>
{
    public async Task Handle(DeleteBlogPostRequest request, CancellationToken cancellationToken)
    {
        var blogPost = await repository.GetByIdAsync(request.BlogPostId, cancellationToken);

        await repository.DeleteAsync(blogPost, cancellationToken);
    }
}
