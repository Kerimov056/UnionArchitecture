using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BlogImageService : IBlogImageService
{
    private readonly IBlogImageReadReopsitory _blogImageReadReopsitory;
    private readonly IBlogImageWriteReopsitory _blogImageWriteReopsitory;
    private readonly IBlogReadReopsitory _blogReadReopsitory;
    private readonly IStorageFile _uploadFile;
    private readonly IMapper _mapper;
    public BlogImageService(IBlogImageReadReopsitory blogImageReadReopsitory,
        IBlogImageWriteReopsitory blogImageWriteReopsitory,
        IBlogReadReopsitory blogReadReopsitory,
        IMapper mapper,
        IStorageFile uploadFile)
    {
        _blogImageReadReopsitory = blogImageReadReopsitory;
        _blogReadReopsitory = blogReadReopsitory;
        _blogImageWriteReopsitory = blogImageWriteReopsitory;
        _mapper = mapper;
        _uploadFile = uploadFile;
    }

    public async Task AddAsync(BlogImageCreateDTO blogImageCreateDTO)
    {
        var BlogImage = _mapper.Map<BlogImage>(blogImageCreateDTO);
        await _blogImageWriteReopsitory.AddAsync(BlogImage);
        await _blogImageWriteReopsitory.SaveChangeAsync();
    }

    public async Task Update(Guid BlogId,BlogImageUpdateDTO blogImageUpdateDTO)
    {
        var blog = await _blogReadReopsitory.GetByIdAsync(BlogId);
        if (blog is null) throw new NotFoundException("Blog is Null");
        var ByBlog = _mapper.Map<BlogImage>(blogImageUpdateDTO);
        _blogImageWriteReopsitory.Update(ByBlog);
        await _blogImageWriteReopsitory.SaveChangeAsync();
    }
}
