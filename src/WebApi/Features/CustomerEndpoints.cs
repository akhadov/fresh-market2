using FreshMarket.Application.Customers.Commands.Create;
using FreshMarket.WebApi.Extensions;
using MediatR;

namespace FreshMarket.WebApi.Features;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("customers")
            .WithTags("Customers")
            .WithOpenApi();

        //group
        //    .MapGet("/", (ISender sender, CancellationToken ct)
        //        => sender.Send(new GetAllTodoItemsQuery(), ct))
        //    .WithName("GetTodoItems")
        //    .ProducesGet<TodoItemDto[]>();

        group
            .MapPost("/", (ISender sender, CreateCustomerRequest request, CancellationToken ct) => sender.Send(request, ct))
            .WithName("CreateCustomer")
            .ProducesPost();

        //group
        //   .MapPut("/", (ISender sender, UpdateProductRequest request, CancellationToken ct) => sender.Send(request, ct))
        //   .WithName("UpdateProduct")
        //   .ProducesPut();
    }
}