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
    private readonly IFlowersImageWriteRepository _flowersImageWriteRepository;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;
    public FlowerService(IFlowersReadRepository flowersReadRepository,
                         IFlowersWriteRepository flowersWriteRepository,
                         IMapper mapper,
                         IFlowersDetailsWriteRepository flowersDetailsWriteRepository,
                         AppDbContext appDbContext,
                         IFlowersImageWriteRepository flowersImageWriteRepository,
                         ITagService tagService)
    {
        _flowersReadRepository = flowersReadRepository;
        _flowersWriteRepository = flowersWriteRepository;
        _mapper = mapper;
        _flowersDetailsWriteRepository = flowersDetailsWriteRepository;
        _appDbContext = appDbContext;
        _flowersImageWriteRepository = flowersImageWriteRepository;
        _tagService = tagService;
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

        FlowersImage flowersImage = new()
        {
            ImagePath = createDTO.FlowersImageDTO.ImagePath,
            FlowersId = newFlower.Id
        };
        await _flowersImageWriteRepository.AddAsync(flowersImage);
       
        foreach (var item in await _tagService.GetAllAsync())
        {
            var flower_tag = new Flower_Tag
            {
                TagsId = item.Id,
                FlowersId = newFlower.Id
            };
            //tag'e add elemek lazimdi.Burda Ayri bir Repository  
            await _appDbContext.Flower_Tags.AddAsync(flower_tag);
        }
        await _flowersWriteRepository.SaveChangeAsync();
    }

    public async Task<List<FlowerGetDTO>> GetAllAsync()
    {
        var flower = await _flowersReadRepository
                .GetAll()
                .Include(x => x.FlowersDetails)
                .Include(x => x.Images)
                .Include(x => x.Flower_Tags)
                .ThenInclude(x=>x.Tags)
                .ToListAsync();
        
        var FlowerGetDto = _mapper.Map<List<FlowerGetDTO>>(flower);
        return FlowerGetDto;
    }

    //.Include(x => x.FlowersDetails)
    //.Include(x => x.Images)
    //.Include(x => x.Flower_Tags)
    //.ThenInclude(x => x.Tags)
    public Task<FlowerGetDTO> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(Guid id)
    {
        var flower = await _flowersReadRepository.GetByIdAsync(id);
        if (flower is null) throw new NullReferenceException();
        _flowersWriteRepository.Remove(flower);
        await _flowersWriteRepository.SaveChangeAsync();
    }

    public async Task UpdateAsync(Guid id, FlowerUptadeDTO flowerUptadeDTO)
    {
        var flower = await _flowersReadRepository.GetByIdAsync(id);
        if (flower is null) throw new NullReferenceException();

        var NewFlpwer =  _mapper.Map<Flowers>(flowerUptadeDTO);
        _flowersWriteRepository.Update(NewFlpwer);
        await _flowersWriteRepository.SaveChangeAsync();
    }
}
