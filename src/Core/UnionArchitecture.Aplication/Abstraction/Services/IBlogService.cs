using UnionArchitecture.Aplication.DTOs.Blog;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IBlogService
{
    Task<List<BlogGetDTO>> GetAllAsync();
    Task AddAsync(BlogCreateDTO blogCreateDTO);
    Task<BlogGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid Id,BlogUpdateDTo blogUpdateDTo);
    Task RemoveAsync(Guid Id);
}
