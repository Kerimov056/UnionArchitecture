using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.Flowers;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class FlowerService : IFlowerService
{
    private readonly IFlowersReadRepository _flowersReadRepository;
    private readonly IFlowersWriteRepository _flowersWriteRepository;
    private readonly IMapper _mapper;
    public FlowerService(IFlowersReadRepository flowersReadRepository, IFlowersWriteRepository flowersWriteRepository,IMapper mapper)
    {
        _flowersReadRepository = flowersReadRepository;
        _flowersWriteRepository = flowersWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(FlowerCreateDTO createDTO)
    {
        Flowers? flowers = await _flowersReadRepository
               .GetByIdAsyncExpression(f => f.Name.ToLower().Equals(createDTO.name));
        if (flowers is not null) throw new DublicatedException("Dubilcated Catagory Name!");
        Flowers newFlower = _mapper.Map<Flowers>(createDTO);
        await _flowersWriteRepository.AddAsync(newFlower);
        await _flowersWriteRepository.SaveChangeAsync();
    }

    public async Task<List<FlowerGetDTO>> GetAllAsync()
    {
        var flower = await _flowersReadRepository.GetAll().ToListAsync();
        var FlowerGetDto = _mapper.Map<List<FlowerGetDTO>>(flower);
        return FlowerGetDto;
    }

    public Task<FlowerGetDTO> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, FlowerUptadeDTO flowerUptadeDTO)
    {
        throw new NotImplementedException();
    }
}
