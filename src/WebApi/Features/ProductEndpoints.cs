using Application.Products.Queries;
using FreshMarket.Application.Products.Commands.Create;
using FreshMarket.Application.Products.Commands.Delete;
using FreshMarket.Application.Products.Commands.Update;
using FreshMarket.WebApi.Extensions;
using MediatR;

namespace FreshMarket.WebApi.Features;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("products")
            .WithTags("products")
            .WithOpenApi();

        group
            .MapGet("/{productId:guid}", async (ISender sender, Guid productId, CancellationToken ct) =>
            {
                var query = new GetProductQuery(productId);
                var product = await sender.Send(query, ct);
                return Results.Ok(product);
            })
            .WithName("GetProduct")
            .Produces<ProductResponse>();

        //group
        //    .MapGet("/", (ISender sender, CancellationToken ct)
        //        => sender.Send(new GetAllTodoItemsQuery(), ct))
        //    .WithName("GetTodoItems")
        //    .ProducesGet<TodoItemDto[]>();

        group
            .MapPost("/", (ISender sender, CreateProductRequest request, CancellationToken ct) => sender.Send(request, ct))
            .WithName("CreateProduct")
            .ProducesPost();

        group
           .MapPut("/", (ISender sender, UpdateProductRequest request, CancellationToken ct) => sender.Send(request, ct))
           .WithName("UpdateProduct")
           .ProducesPut();

        group
           .MapDelete("/{productId:guid}",
               async (ISender sender, Guid productId, CancellationToken ct) =>
               {
                   var command = new DeleteProductRequest(productId);
                   await sender.Send(command, ct);
                   return Results.NoContent();
               })
           .WithName("DeleteProduct")
           .ProducesDelete();
    }
}