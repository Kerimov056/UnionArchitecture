using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogUpdateDTo(IFormFile imagePath, string title, string description,Guid catagoryId, BlogImageGetDTO BlogImageGetDTO);