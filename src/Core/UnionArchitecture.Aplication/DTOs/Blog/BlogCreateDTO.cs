using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Blog;

public record BlogCreateDTO(IFormFile imagePath,
                            string title,
                            string description,
                            Guid CatagoryId,
                            BlogImageGetDTO BlogImageGetDTO);