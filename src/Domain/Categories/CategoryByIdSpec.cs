using Ardalis.Specification;


namespace FreshMarket.Domain.Categories;
public sealed class CategoryByIdSpec : SingleResultSpecification<Category>
{
    public CategoryByIdSpec(CategoryId categoryId) => Query
        .Where(c => c.Id == categoryId);
}
