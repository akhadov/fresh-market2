using FreshMarket.Domain.Common.Base;

namespace Domain.Blogs;

public record BlogPostCommentCreatedEvent(BlogPostCommentId Id, string CommentText) : DomainEvent
{
    public static BlogPostCommentCreatedEvent Create(BlogPostComment blogPostComment) => new(blogPostComment.Id, blogPostComment.CommentText);
}
