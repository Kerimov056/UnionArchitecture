using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.Flowers;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class FlowerService : IFlowerService
{
    private readonly IFlowersReadRepository _flowersReadRepository;
    private readonly IFlowersWriteRepository _flowersWriteRepository;
    private readonly IFlowersDetailsWriteRepository _flowersDetailsWriteRepository;
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;
    public FlowerService(IFlowersReadRepository flowersReadRepository,
                         IFlowersWriteRepository flowersWriteRepository,
                         IMapper mapper,
                         IFlowersDetailsWriteRepository flowersDetailsWriteRepository,
                         AppDbContext appDbContext)
    {
        _flowersReadRepository = flowersReadRepository;
        _flowersWriteRepository = flowersWriteRepository;
        _mapper = mapper;
        _flowersDetailsWriteRepository = flowersDetailsWriteRepository;
        _appDbContext = appDbContext;
    }

    public async Task CreateAsync(FlowerCreateDTO createDTO)
    {
        Flowers? flowers = await _flowersReadRepository
               .GetByIdAsyncExpression(f => f.Name.ToLower().Equals(createDTO.name));
        if (flowers is not null) throw new DublicatedException("Dubilcated Catagory Name!");

        Flowers newFlower = _mapper.Map<Flowers>(createDTO);
        newFlower.ImagePath = createDTO.image;

        await _flowersWriteRepository.AddAsync(newFlower);
        await _flowersWriteRepository.SaveChangeAsync();
        //692e11b0-216f-4722-3c8d-08db87e58ba6
        FlowersDetails FDetailEntity = new()
        {
            Description = createDTO.FlowerDetailsCreateDTOs.Description,
            SKU = createDTO.FlowerDetailsCreateDTOs.SKU,
            Weight = createDTO.FlowerDetailsCreateDTOs.Weight,
            PowerFlowers = createDTO.FlowerDetailsCreateDTOs.PowerFlowers,
            FlowersId = newFlower.Id
        };
        await _flowersDetailsWriteRepository.AddAsync(FDetailEntity);

        //Yaziriq ama Repository'e cevireceyik
        FlowersImage flowersImage = new()
        {
            ImagePath = createDTO.FlowersImageDTO.ImagePath,
            FlowersId = newFlower.Id
        };
        await _appDbContext.FlowersImages.AddAsync(flowersImage);
       
        foreach (var item in _appDbContext.Tags)
        {
            var flower_tag = new Flower_Tag
            {
                TagsId = item.Id,
                FlowersId = newFlower.Id
            };
            //tag'e add elemek lazimdi burda
            _appDbContext.Flower_Tags.Add(flower_tag);
        }
        await _appDbContext.SaveChangesAsync();

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
