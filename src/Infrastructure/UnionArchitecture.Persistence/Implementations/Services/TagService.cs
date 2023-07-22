using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.TagDTOs;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class TagService : ITagService
{
    private readonly ITagReadRepository _tagReadRepository;
    private readonly ITagWriteRepository _tagWriteRepository;
    private readonly IMapper _mapper;
    
    public TagService(ITagReadRepository tagReadRepository,
                      ITagWriteRepository tagWriteRepository,
                      IMapper mapper)
    {
        _tagReadRepository = tagReadRepository;
        _tagWriteRepository = tagWriteRepository;
        _mapper = mapper;
    }
    public Task CreateAsync(TagCreateDTOs tagCreateDTOs)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TagGetDTOs>> GetAllAsync()
    {
        var tags = await _tagReadRepository.GetAll().ToListAsync();
        var EntityToDto = _mapper.Map<List<TagGetDTOs>>(tags);
        return EntityToDto;
    }

    public async Task<TagGetDTOs> GetByIdAsync(Guid Id)
    {
        var tag = await _tagReadRepository.GetByIdAsync(Id);
        if (tag is null) throw new NullReferenceException("There is no tag with this name");
        var ByTag = _mapper.Map<TagGetDTOs>(tag);
        return ByTag;
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, TagUptadeDTO tagUptadeDTO)
    {
        throw new NotImplementedException();
    }
}
