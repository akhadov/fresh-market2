using MediatR;

namespace Application.Categories.Queries;

public sealed record GetCategoryQuery(Guid CategoryId) : IRequest<CategoryResponse>;
