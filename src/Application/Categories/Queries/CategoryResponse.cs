namespace Application.Categories.Queries;

public record CategoryResponse
{
    public Guid CategoryId { get; init; }
    public string Name { get; init; }
    public string ImagePath { get; init; }

}