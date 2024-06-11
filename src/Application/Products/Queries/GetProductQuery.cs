using MediatR;

namespace Application.Products.Queries;

public sealed record GetProductQuery(Guid ProductId) : IRequest<ProductResponse>;
