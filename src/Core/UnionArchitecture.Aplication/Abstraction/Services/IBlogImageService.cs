using UnionArchitecture.Aplication.DTOs.Blog;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IBlogImageService
{
    Task AddAsync(BlogImageCreateDTO blogImageCreateDTO);
}
