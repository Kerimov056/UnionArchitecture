using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class SliderService : ISliderService
{
    private readonly ISliderReadRepository _sliderReadRepository;
    private readonly ISliderWriteRepository _sliderWriteRepository;
    private readonly IMapper _mapper;
    public SliderService(ISliderReadRepository sliderReadRepository,
                         ISliderWriteRepository sliderWriteRepository,
                         IMapper mapper)
    {
        _sliderReadRepository = sliderReadRepository;
        _sliderWriteRepository = sliderWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(SliderCreateDTO sliderCreateDTO)
    {
        var DtoToEntity = _mapper.Map<Slider>(sliderCreateDTO);
        await _sliderWriteRepository.AddAsync(DtoToEntity);
        await _sliderWriteRepository.SaveChangeAsync();
    }

    public async Task<List<SliderGetDTO>> GetAllAsync()
    {
        var silder =  await _sliderReadRepository.GetAll().ToListAsync();
        if (silder is null) throw new NullReferenceException();
        var EntityToDto = _mapper.Map<List<SliderGetDTO>>(silder);
        return EntityToDto;
    }

    public Task<CatagoryGetDTO> GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, SliderUptadeDTO sliderUptadeDTO)
    {
        throw new NotImplementedException();
    }
}
