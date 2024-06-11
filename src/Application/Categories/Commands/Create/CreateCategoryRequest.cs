using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Categories;
using MediatR;

namespace FreshMarket.Application.Categories.Commands.Create;
public sealed record CreateCategoryRequest(string Name, string ImagePath) : IRequest<Guid>;

internal sealed class CreateCategoryRequestHandler(
    IRepository<Category> repository)
    : IRequestHandler<CreateCategoryRequest, Guid>
{
    public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name, request.ImagePath);

        await repository.AddAsync(category, cancellationToken);

        return category.Id.Value;
    }
}