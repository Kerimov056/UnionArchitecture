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
        if (blog is not null) throw new DublicatedException("Dubilcated Catagory Name!");
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
        var blogs = await _blogReadReopsitory
                    .GetAll()
                    .Include(x => x.BlogImages)
                    .Include(x => x.Catagory)
                    .ToListAsync();

        if (blogs is null) throw new NotFoundException("Blog is Null");

        var dtoList = new List<BlogGetDTO>();

        foreach (var blog in blogs)
        {
            var blogGetDTO = new BlogGetDTO
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                ImagePath = blog.ImagePath,
                CatagoryId = blog.CatagoryId,
                BlogImages = new List<BlogImageGetAllDTO>()
            };

            foreach (var blogImage in blog.BlogImages)
            {
                var blogImageGetAllDTO = new BlogImageGetAllDTO
                {
                    Id = blogImage.Id,
                    Image = blogImage.ImagePath,
                    BlogId = blogImage.BlogId
                };

                blogGetDTO.BlogImages.Add(blogImageGetAllDTO);
            }

            dtoList.Add(blogGetDTO);
        }

        return dtoList;
    }


    public async Task<BlogGetDTO> GetByIdAsync(Guid Id)
    {
        var Blogs = await _blogReadReopsitory
                    .GetAll()
                    .Include(x => x.BlogImages)
                    .Include(x => x.Catagory)
                    .FirstOrDefaultAsync(x => x.Id == Id);
        if (Blogs is null) throw new NotFoundException("Blog is null");
        var EntityToDto = _mapper.Map<BlogGetDTO>(Blogs);
        return EntityToDto;
    }

    public async Task RemoveAsync(Guid Id)
    {
        var ByBlog = await _blogReadReopsitory.GetByIdAsync(Id);
        if (ByBlog is null) throw new NotFoundException("Blog is null");
        var DtoToEntity = _mapper.Map<Blog>(ByBlog);
        _blogWriteReopsitory.Remove(DtoToEntity);
        await _blogWriteReopsitory.SaveChangeAsync();
    }
    public async Task UpdateAsync(Guid Id, BlogUpdateDTo blogUpdateDTo)
    {
        var ByBlog = await _blogReadReopsitory.GetByIdAsync(Id);
        if (ByBlog is null) throw new NotFoundException("Blog is null");
        _mapper.Map(blogUpdateDTo, ByBlog);
        _blogWriteReopsitory.Update(ByBlog);
        await _blogWriteReopsitory.SaveChangeAsync();
    }
}
