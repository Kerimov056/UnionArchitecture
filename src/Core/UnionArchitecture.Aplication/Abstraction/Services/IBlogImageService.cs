using UnionArchitecture.Aplication.DTOs.Blog;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IBlogImageService
{
    Task AddAsync(BlogImageCreateDTO blogImageCreateDTO);
    Task Update(Guid BlogID,BlogImageUpdateDTO blogImageUpdateDTO);
}
