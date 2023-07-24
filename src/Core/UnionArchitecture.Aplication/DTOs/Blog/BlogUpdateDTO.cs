namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogUpdateDTo(string imagePath, string title, string description,Guid catagoryId, BlogImageGetDTO BlogImageGetDTO);