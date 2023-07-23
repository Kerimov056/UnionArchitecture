using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BlogImageService : IBlogImageService
{
    private readonly IBlogImageReadReopsitory _blogImageReadReopsitory;
    private readonly IBlogImageWriteReopsitory _blogImageWriteReopsitory;
    private readonly IMapper _mapper;
    public BlogImageService(IBlogImageReadReopsitory blogImageReadReopsitory,
        IBlogImageWriteReopsitory blogImageWriteReopsitory,
        IMapper mapper)
    {
        _blogImageReadReopsitory = blogImageReadReopsitory;
        _blogImageWriteReopsitory = blogImageWriteReopsitory;
        _mapper = mapper;
    }

    public async Task AddAsync(BlogImageCreateDTO blogImageCreateDTO)
    {
        var BlogImage = _mapper.Map<BlogImage>(blogImageCreateDTO);
        await _blogImageWriteReopsitory.AddAsync(BlogImage);
        await _blogImageWriteReopsitory.SaveChangeAsync();
    }
}
