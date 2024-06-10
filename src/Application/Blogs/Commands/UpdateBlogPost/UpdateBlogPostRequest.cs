using Domain.Blogs;
using FreshMarket.Application.Common.Interfaces;
using MediatR;

namespace Application.Blogs.Commands.UpdateBlogPost;

public sealed record UpdateBlogPostRequest(BlogPostId BlogPostId, string Title, string ImagePath, string Body, string BodyOverView)
    : IRequest<Guid>;

internal sealed class UpdateBlogPostRequestHandler(IRepository<BlogPost> repository)
    : IRequestHandler<UpdateBlogPostRequest, Guid>
{
    public async Task<Guid> Handle(UpdateBlogPostRequest request, CancellationToken cancellationToken)
    {
        var blogPost = await repository.GetByIdAsync(request.BlogPostId, cancellationToken);

        blogPost.Update(request.Title, request.ImagePath, request.Body, request.BodyOverView);

        await repository.UpdateAsync(blogPost, cancellationToken);

        return blogPost.Id.Value;
    }
}
