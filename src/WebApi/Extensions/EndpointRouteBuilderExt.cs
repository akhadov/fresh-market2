using Application.Common.Models;

namespace FreshMarket.WebApi.Extensions;

public static class EndpointRouteBuilderExt
{
    public static RouteHandlerBuilder ProducesGet<T>(this RouteHandlerBuilder builder) => builder
        .Produces<T>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

    public static RouteHandlerBuilder ProducesPost(this RouteHandlerBuilder builder) => builder
        .Produces(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .ProducesProblem(StatusCodes.Status500InternalServerError);

    public static RouteHandlerBuilder ProducesPut(this RouteHandlerBuilder builder) => builder
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesValidationProblem()
        .ProducesProblem(StatusCodes.Status500InternalServerError);

    public static RouteHandlerBuilder ProducesDelete(this RouteHandlerBuilder builder) => builder
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
}
