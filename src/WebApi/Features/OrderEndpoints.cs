using FreshMarket.Application.Orders.Commands.AddLineItem;
using FreshMarket.Application.Orders.Commands.Create;
using FreshMarket.Application.Orders.Commands.RemoveLineItem;
using FreshMarket.WebApi.Extensions;
using MediatR;

namespace FreshMarket.WebApi.Features;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("orders")
            .WithTags("orders")
            .WithOpenApi();

        //group
        //    .MapGet("/", (ISender sender, CancellationToken ct)
        //        => sender.Send(new GetAllTodoItemsQuery(), ct))
        //    .WithName("GetTodoItems")
        //    .ProducesGet<TodoItemDto[]>();

        group
            .MapPost("/", (ISender sender, CreateOrderRequest request, CancellationToken ct) => sender.Send(request, ct))
            .WithName("CreateOrder")
            .ProducesPost();

        group
           .MapPut("/", (ISender sender, AddLineItemRequest request, CancellationToken ct) => sender.Send(request, ct))
           .WithName("AddLineItem")
           .ProducesPut();

        group
           .MapDelete("/{orderId:guid}/line-items/{lineItemId:guid}",
               async (ISender sender, Guid orderId, Guid lineItemId, CancellationToken ct) =>
               {
                   var command = new RemoveLineItemRequest(orderId, lineItemId);
                   await sender.Send(command, ct);
                   return Results.NoContent();
               })
           .WithName("RemoveLineItem")
           .ProducesDelete();
    }
}