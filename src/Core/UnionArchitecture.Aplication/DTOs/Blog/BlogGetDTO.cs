namespace UnionArchitecture.Aplication.DTOs.Blog;

public class BlogGetDTO
{
    public Guid Id { get; init; }
    public string ImagePath { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public Guid CatagoryId { get; init; }
    public List<BlogImageGetAllDTO> BlogImages { get; set; }
}
