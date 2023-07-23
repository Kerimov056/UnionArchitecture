using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BlogService : IBlogService
{
    public Task AddAsync(BlogCreateDTO blogCreateDTO)
    {
        
    }

    public Task<List<BlogGetDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BlogGetDTO> GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid Id, BlogUpdateDTo blogUpdateDTo)
    {
        throw new NotImplementedException();
    }
}
