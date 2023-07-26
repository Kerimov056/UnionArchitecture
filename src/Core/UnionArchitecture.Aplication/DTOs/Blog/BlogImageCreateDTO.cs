using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogImageCreateDTO(Guid BlogId, string ImagePath);