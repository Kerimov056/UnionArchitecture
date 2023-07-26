using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class BlogImageService : IBlogImageService
{
    private readonly IBlogImageReadReopsitory _blogImageReadReopsitory;
    private readonly IBlogImageWriteReopsitory _blogImageWriteReopsitory;
    private readonly IUploadFile _uploadFile;
    private readonly IMapper _mapper;
    public BlogImageService(IBlogImageReadReopsitory blogImageReadReopsitory,
        IBlogImageWriteReopsitory blogImageWriteReopsitory,
        IMapper mapper,
        IUploadFile uploadFile)
    {
        _blogImageReadReopsitory = blogImageReadReopsitory;
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
}
