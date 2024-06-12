using Domain.Blogs;
using FreshMarket.Application.Common.Interfaces;
using MediatR;

namespace Application.Blogs.Queries;

internal sealed class GetBlogPostQueryHandler(IRepository<BlogPost> repository)
    : IRequestHandler<GetBlogPostQuery, BlogPostResponse>
{
    public async Task<BlogPostResponse> Handle(GetBlogPostQuery request, CancellationToken cancellationToken)
    {
        var blogPost = await repository.GetByIdAsync(new BlogPostId(request.BlogPostId), cancellationToken);

        var blogPostResponse = new BlogPostResponse
        {
            BlogPostId = blogPost.Id.Value,
            CustomerId = blogPost.CustomerId.Value,
            Title = blogPost.Title,
            ImagePath = blogPost.ImagePath,
            Body = blogPost.Body,
            BodyOverview = blogPost.BodyOverview
        };

        return blogPostResponse;
    }
}
