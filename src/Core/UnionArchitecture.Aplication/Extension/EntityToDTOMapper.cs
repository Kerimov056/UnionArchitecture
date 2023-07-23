using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Domain.Extension;

public static class EntityToDTOMapper
{
    public static BlogImageGetAllDTO BlogImageGetAllDTO(BlogImage blogImage)
    {
        return new BlogImageGetAllDTO
        {
            BlogId = blogImage.BlogId,
            Image = blogImage.ImagePath,
            Id= blogImage.Id
        };
    }
}
