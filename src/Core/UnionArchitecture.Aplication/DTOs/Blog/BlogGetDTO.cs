namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogGetDTO
{
    public Guid Id { get; init; } 
    public string ImagePath { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public Guid CatagoryId { get; init; }
    public List<BlogImageGetAllDTO> BlogImageGetAllDTO { get; init; }
}
