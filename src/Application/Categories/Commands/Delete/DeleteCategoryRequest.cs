using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Categories;
using MediatR;

namespace FreshMarket.Application.Categories.Commands.Delete;
public sealed record DeleteCategoryRequest(Guid CategoryId) : IRequest<Guid>;

internal sealed class DeleteCategoryRequestHandler(IRepository<Category> repository) : IRequestHandler<DeleteCategoryRequest, Guid>
{
    public async Task<Guid> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {

        var category = await repository.GetByIdAsync(new CategoryId(request.CategoryId), cancellationToken);

        await repository.DeleteAsync(category, cancellationToken);

        return request.CategoryId;
    }
}
