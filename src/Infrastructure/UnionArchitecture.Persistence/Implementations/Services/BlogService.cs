using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BlogService : IBlogService
{
    private readonly IBlogReadReopsitory _blogReadReopsitory;
    public readonly IBlogWriteReopsitory _blogWriteReopsitory;
    public readonly IMapper _mapper;
    public BlogService(IBlogReadReopsitory blogReadReopsitory,
                       IBlogWriteReopsitory blogWriteReopsitory,
                       IMapper mapper)
    {
        _blogReadReopsitory = blogReadReopsitory;
        _blogWriteReopsitory = blogWriteReopsitory;
        _mapper = mapper;
    }

    public async Task AddAsync(BlogCreateDTO blogCreateDTO)
    {
        var blog = await _blogReadReopsitory
            .GetByIdAsyncExpression(x => x.Title.ToLower().Equals(blogCreateDTO.title));
        if (blog is not null) throw new NullReferenceException("Dubilcated Catagory Name!");
        Blog NewBlog = _mapper.Map<Blog>(blogCreateDTO);
        await _blogWriteReopsitory.AddAsync(NewBlog);
        await _blogWriteReopsitory.SaveChangeAsync();
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
