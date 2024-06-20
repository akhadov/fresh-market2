using Application.Blogs.Commands.CreateBlogPost;
using Application.Blogs.Commands.DeleteBlogPost;
using Application.Blogs.Commands.UpdateBlogPost;
using Application.Blogs.Queries;
using FreshMarket.WebApi.Extensions;
using MediatR;

namespace WebApi.Features;

public static class BlogPostEndpoints
{
    public static void MapBlogPostEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("blogPosts")
            .WithTags("BlogPosts")
            .WithOpenApi();

        group
            .MapGet("/{blogPostId:guid}", async (ISender sender, Guid blogPostId, CancellationToken ct) =>
            {
                var query = new GetBlogPostQuery(blogPostId);
                var blogPost = await sender.Send(query, ct);
                return Results.Ok(blogPost);
            })
            .WithName("GetBlogPost")
            .Produces<BlogPostResponse>();

        //group
        //    .MapGet("/", (ISender sender, CancellationToken ct)
        //        => sender.Send(new GetAllTodoItemsQuery(), ct))
        //    .WithName("GetTodoItems")
        //    .ProducesGet<TodoItemDto[]>();

        group
            .MapPost("/", (ISender sender, CreateBlogPostRequest request, CancellationToken ct) => sender.Send(request, ct))
            .WithName("CreateBlogPost")
            .ProducesPost();

        group
           .MapPut("/", (ISender sender, UpdateBlogPostRequest request, CancellationToken ct) => sender.Send(request, ct))
           .WithName("UpdateBlogPost")
           .ProducesPut();

        group
            .MapDelete("/{blogPostId:guid}",
                async (ISender sender, Guid blogPostId, CancellationToken ct) =>
                {
                    var command = new DeleteBlogPostRequest(blogPostId);
                    await sender.Send(command, ct);
                    return Results.NoContent();
                })
            .WithName("DeleteBlogPost")
            .ProducesDelete();
    }
}
