using Application.Common.Models;
using MediatR;

namespace Application.Products.Queries;

public sealed record GetProductsQuery(int Page, int PageSize) : IRequest<PagedList<ProductResponse>>;
