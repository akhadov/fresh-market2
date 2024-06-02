using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Categories;
using MediatR;

namespace FreshMarket.Application.Categories.Commands.Update;
public sealed record UpdateCategoryRequest(CategoryId CategoryId, string Name, string ImagePath) : IRequest;

internal sealed class UpdateCategoryRequestHandler(IRepository<Category> repository)
    : IRequestHandler<UpdateCategoryRequest>
{
    public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.CategoryId, cancellationToken);

        category.Update(request.Name, request.ImagePath);

        await repository.UpdateAsync(category, cancellationToken);
    }
}