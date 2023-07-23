using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BlogService : IBlogService
{
    private readonly IBlogReadReopsitory _blogReadReopsitory;
    public readonly IBlogWriteReopsitory _blogWriteReopsitory;
    private readonly IBlogImageService _blogImageService;
    public readonly IMapper _mapper;
    public BlogService(IBlogReadReopsitory blogReadReopsitory,
                       IBlogWriteReopsitory blogWriteReopsitory,
                       IMapper mapper,
                       IBlogImageService blogImageService)
    {
        _blogReadReopsitory = blogReadReopsitory;
        _blogWriteReopsitory = blogWriteReopsitory;
        _mapper = mapper;
        _blogImageService = blogImageService;
    }

    public async Task AddAsync(BlogCreateDTO blogCreateDTO)
    {
        var blog = await _blogReadReopsitory
            .GetByIdAsyncExpression(x => x.Title.ToLower().Equals(blogCreateDTO.title));
        if (blog is not null) throw new NullReferenceException("Dubilcated Catagory Name!");
        Blog NewBlog = _mapper.Map<Blog>(blogCreateDTO);
        await _blogWriteReopsitory.AddAsync(NewBlog);
        await _blogWriteReopsitory.SaveChangeAsync();

        NewBlogDto newBlogDto = new()
        {
            BlogId = NewBlog.Id,
            ImagePath = NewBlog.ImagePath
        };
        var NewBlogImage = _mapper.Map<BlogImageCreateDTO>(newBlogDto);
        await _blogImageService.AddAsync(NewBlogImage);
    }


    public async Task<List<BlogGetDTO>> GetAllAsync()
    {
        var Blogs = await _blogReadReopsitory
                    .GetAll()
                    .Include(x => x.BlogImages)
                    .Include(x => x.Catagory)
                    .ToListAsync();
        if (Blogs is null) throw new NotFoundException("Blog is Null");
        var EntityToDto = _mapper.Map<List<BlogGetDTO>>(Blogs);
        return EntityToDto;
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
