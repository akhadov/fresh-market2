using MediatR;

namespace Application.Blogs.Queries;

public sealed record GetBlogPostQuery(Guid BlogPostId) : IRequest<BlogPostResponse>;
