namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogGetDTO(Guid id,string imagePath,string title,string description, BlogImageGetDTO BlogImageGetDTO);