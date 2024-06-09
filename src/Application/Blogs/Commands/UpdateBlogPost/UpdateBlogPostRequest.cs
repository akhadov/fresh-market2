using MediatR;

namespace Application.Blogs.Commands.UpdateBlogPost;

public sealed record UpdateBlogPostRequest(Guid BlogPostId) : IRequest<Guid>;
