using Application.Orders.Queries.GetOrder;
using Application.Products.Queries;
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
            .WithTags("Orders")
            .WithOpenApi();

        group
            .MapGet("/{orderId:guid}", async (ISender sender, Guid orderId, CancellationToken ct) =>
            {
                var query = new GetProductQuery(orderId);
                var order = await sender.Send(query, ct);
                return Results.Ok(order);
            })
            .WithName("GetOrder")
            .ProducesGet<OrderResponse>();

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