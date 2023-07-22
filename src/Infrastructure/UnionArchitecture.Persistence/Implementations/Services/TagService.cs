using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.TagDTOs;
using UnionArchitecture.Persistence.Exceptions;
using UnionArchitecture.Persistence.Migrations;
using UnionArchitecture.Domain.Entities;

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
    public async Task CreateAsync(TagCreateDTOs tagCreateDTOs)
    {
        //Tags? tags = await _tagReadRepository
        //    .GetByIdAsyncExpression(c => c.Tag.ToLower().Equals(tagCreateDTOs.tag));
        //if (tags is not null) throw new DublicatedException("Dubilcated Tag Name!");

        //var DtoToTag = _mapper.Map<Tags>();
        //await _tagWriteRepository.AddAsync(DtoToTag);
        //await _tagWriteRepository.SaveChangeAsync();
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

    public async Task RemoveAsync(Guid id)
    {
        var tag = await _tagReadRepository.GetByIdAsync(id);
        if (tag is null) throw new ArgumentNullException();
        _tagWriteRepository.Remove(tag);
        await _tagWriteRepository.SaveChangeAsync();
    }

    public async Task UpdateAsync(Guid id, TagUptadeDTO tagUptadeDTO)
    {
        var tag = await _tagReadRepository.GetByIdAsync(id);
        if (tag is null) throw new ArgumentNullException();
        _mapper.Map(tagUptadeDTO, tag);
        _tagWriteRepository.Update(tag);
        await _tagWriteRepository.SaveChangeAsync();
    }
}
