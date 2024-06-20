using Application.Categories.Queries;
using FreshMarket.Application.Categories.Commands.Create;
using FreshMarket.Application.Categories.Commands.Delete;
using FreshMarket.Application.Categories.Commands.Update;
using FreshMarket.WebApi.Extensions;
using MediatR;

namespace FreshMarket.WebApi.Features;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("categories")
            .WithTags("Categories")
            .WithOpenApi();

        group
            .MapGet("/{categoryId:guid}", async (ISender sender, Guid categoryId, CancellationToken ct) =>
            {
                var query = new GetCategoryQuery(categoryId);
                var category = await sender.Send(query, ct);
                return Results.Ok(category);
            })
            .WithName("GetCategory")
            .Produces<CategoryResponse>();

        //group
        //    .MapGet("/", (ISender sender, CancellationToken ct)
        //        => sender.Send(new GetAllTodoItemsQuery(), ct))
        //    .WithName("GetTodoItems")
        //    .ProducesGet<TodoItemDto[]>();

        group
            .MapPost("/", (ISender sender, CreateCategoryRequest request, CancellationToken ct) => sender.Send(request, ct))
            .WithName("CreateCategory")
            .ProducesPost();

        group
           .MapPut("/", (ISender sender, UpdateCategoryRequest request, CancellationToken ct) => sender.Send(request, ct))
           .WithName("UpdateCategory")
           .ProducesPut();

        group
            .MapDelete("/{categoryId:guid}",
                async (ISender sender, Guid categoryId, CancellationToken ct) =>
                {
                    var command = new DeleteCategoryRequest(categoryId);
                    await sender.Send(command, ct);
                    return Results.NoContent();
                })
            .WithName("DeleteCategory")
            .ProducesDelete();
    }
}