using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Categories;
using MediatR;

namespace Application.Categories.Queries;

internal sealed class GetCategoryQueryHandler(IRepository<Category> repository)
    : IRequestHandler<GetCategoryQuery, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(new CategoryId(request.CategoryId), cancellationToken);

        var categoryResponse = new CategoryResponse
        {
            CategoryId = category.Id.Value,
            Name = category.Name,
            ImagePath = category.ImagePath,
        };

        return categoryResponse;
    }
}
